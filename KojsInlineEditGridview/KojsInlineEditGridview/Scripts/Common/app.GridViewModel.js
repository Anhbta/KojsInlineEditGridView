(function (app, $) {

    app.GridViewModel = function (options) {
        var self = this;

        /*
        * private properties
        */
        var _criteria = options.Criteria || { PageSize: 10, PageIndex: 1, SortExpression: "", SortDirection: "" };
        var _dataSourceUrl = options.DataSourceUrl;
        var _targetDom = options.TargetDom;
        var _isInlineEdit = options.InlineEdit || false;
        var _originalEditObject = null;
        

        /*
        * observable properties
        */
        self.totalPages = ko.observable(0);
        self.totalRecords = ko.observable();

        self.currentPageIndex = ko.observable(1);
        self.selectedRowIndex = ko.observable(0);

        self.listDataItems = ko.observableArray();

        self.numPageSize = [10, 15, 20, 50, 100];   
        self.selectedPageSize = ko.observable(_criteria.PageSize);

        //editing row index
        self.editingRowIndex = ko.observable(-1); // init as not edit
                
        self.sortOrder = ko.observable("ASC");
        self.sortExpression = ko.observable();

        self.isCreateNewInline = ko.observable(false);

        /*
        * computed functions
        */
        self.numPages = ko.computed(function () {
            var arr = [];
            for (var i = 0; i < self.totalPages() ; i++) {
                arr[i] = i + 1;
            }
            return arr;
        });

        //current page index change
        self.currentPageIndexChange = ko.computed(function () {
            if (self.currentPageIndex() != null && _criteria.PageIndex !== self.currentPageIndex()) {
                _criteria.PageIndex = self.currentPageIndex();
                loadData();
                self.selectedRowIndex(0);
            }
        });

        self.selectedPageSizeChange = ko.computed(function () {
            if (self.selectedPageSize() != null && _criteria.PageSize !== self.selectedPageSize()) {                
                _criteria.PageSize = self.selectedPageSize();
                _criteria.PageIndex = 1; self.currentPageIndex(1);
                loadData();
                self.selectedRowIndex(0);
            }
        });

        /*
        *  public functions
        */
        self.selectRow = function (index) {
            self.selectedRowIndex(index);
            return true;
        }

        self.moveSelectedUp = function () {
            var index = self.selectedRowIndex();

            if (index > 0) {
                index--;
                self.selectedRowIndex(index);
            }
        }

        self.moveSelectedDown = function () {
            var index = self.selectedRowIndex();

            if (index < self.listDataItems().length - 1) {
                index++;
                self.selectedRowIndex(index);
            }
        }

        self.nextPage = function () {
            var index = self.currentPageIndex();
            if (index < self.totalPages()) {
                index++;
                self.currentPageIndex(index);
            }
        }

        self.prevPage = function () {
            var index = self.currentPageIndex();
            if (index > 1) {
                index--;
                self.currentPageIndex(index);
            }
        }

        self.enterPage = function (index) {
            self.currentPageIndex(index);
        }

        self.firstPage = function () {
            var index = self.currentPageIndex();
            if (index > 1) {
                index = 1;
                self.currentPageIndex(index);
            }
        }

        self.lastPage = function () {
            var index = self.currentPageIndex();
            if (index !== self.totalPages() && self.totalPages() > 0) {
                self.currentPageIndex(self.totalPages());
            }
        }

        self.nextPageSize = function () {
            for (var i = 0; i < self.numPageSize.length - 1; i++) {
                if (self.numPageSize[i] === self.selectedPageSize()) {
                    self.selectedPageSize(self.numPageSize[i + 1]);
                    break;
                }
            }
        }
        self.prevPageSize = function () {
            for (var i = 1; i < self.numPageSize.length; i++) {
                if (self.numPageSize[i] === self.selectedPageSize()) {
                    self.selectedPageSize(self.numPageSize[i - 1]);
                    break;
                }
            }
        }

        self.sortBy = function (expression) {
            if (self.sortExpression() === expression)
                self.sortOrder(self.sortOrder() === "ASC" ? "DESC" : "ASC");
            else
                self.sortOrder('ASC');
            self.sortExpression(expression);

            _criteria.SortExpression = self.sortExpression();
            _criteria.SortOrder = self.sortOrder();
            loadData();
        }

        self.sort = function (expression, sortdirection) {
            self.sortExpression(expression);
            self.sortOrder(sortdirection);

            _criteria.SortExpression = self.sortExpression();
            _criteria.SortOrder = self.sortOrder();
            loadData();
        }

        self.selectedItem = function () {
            if (self.listDataItems().length > 0 && self.selectedRowIndex() >= 0)
                return ko.mapping.toJS(self.listDataItems()[self.selectedRowIndex()]);
            else
                return null;
        }

        self.updateSelectedItem = function (data) {
            self.listDataItems.replace(self.listDataItems()[self.selectedRowIndex()], data);
        }

        self.createNewItem = function (data) {
            if (self.listDataItems() == null)
                self.listDataItems([]);
            self.listDataItems.push(data);
        }

        self.onAfterDelete = null;

        self.deleteItem = function (item) {
            self.listDataItems.remove(item);
            var index = self.selectedRowIndex();
            if (index === self.listDataItems().length) {
                index--;
                self.selectedRowIndex(index);
            }

            if (self.onAfterDelete != null)
                self.onAfterDelete();
        }

        //search function
        self.search = function (criteria, callback) {
            if (criteria != null) {
                _criteria.PageIndex = 1;
                $.extend(_criteria, criteria);
                loadData(callback);
                self.currentPageIndex(1);
                self.selectedRowIndex(0);
            }
        }

        self.active = function (isActive) {
        }

        self.enableInlineEdit = function (enable) {
            _isInlineEdit = enable;
        }

        self.setDataSourceUrl = function (url) {
            _dataSourceUrl = url;
        }

        /*
        * Inline edit functions
        */
        self.mapping = null;
        self.applyValidationRules = null;
        self.editInline = function (index, data, event) {
            if (!_isInlineEdit || self.editingRowIndex() !== -1)
                return;

            self.editingRowIndex(index);
            _originalEditObject = data;

            var obj = self.mapping == null ? ko.mapping.fromJS(data) : ko.mapping.fromJS(data, self.mapping);

            if (self.applyValidationRules != null) {
                self.applyValidationRules(obj);
                self.errors = ko.validation.group(obj);
            }

            self.listDataItems.replace(self.listDataItems()[index], obj);
        }

        self.editInline2 = function (index, data, event) {
          
            self.editingRowIndex(index);
            _originalEditObject = data;

            var obj = self.mapping == null ? ko.mapping.fromJS(data) : ko.mapping.fromJS(data, self.mapping);

            if (self.applyValidationRules != null) {
                self.applyValidationRules(obj);
                self.errors = ko.validation.group(obj);
            }

            self.listDataItems.replace(self.listDataItems()[index], obj);
        }

        self.editInlineCurrentSelectedRow = function () {
            if (_isInlineEdit) {
                self.editInline(self.selectedRowIndex(), self.listDataItems()[self.selectedRowIndex()]);
            }
        }

        self.onAfterSave = null;
        self.saveInline = function (index, data) {
            if (_isInlineEdit == true && self.errors().length === 0) {
                var value = ko.mapping.toJS(data);
                if (self.onSaveInline != null)
                    self.onSaveInline(value);


                self.editingRowIndex(-1);
                self.isCreateNewInline(false);

                self.listDataItems.replace(self.listDataItems()[index], value);

                if (self.onAfterSave != null)
                    self.onAfterSave();
            }
            else if (self.errors().length > 0) self.errors.showAllMessages();
        }

        self.onSaveInline2 = null;
        self.saveInline2 = function (index, data) {
            if (_isInlineEdit == true && self.errors().length === 0) {
                var value = ko.mapping.toJS(data);
                if (self.onSaveInline2 != null) {
                    //SAVE BUT ALLOW SOME VALIDATION HANDLING FIRST AND SHOW ERRORS IF ANY
                    if (!self.onSaveInline2(value, data)) {
                        return false;
                    }
                }

                self.editingRowIndex(-1);
                self.isCreateNewInline(false);

                self.listDataItems.replace(self.listDataItems()[index], value);

                if (self.onAfterSave != null)
                    self.onAfterSave();
            }
            else if (self.errors().length > 0) {
                if (self.onSaveInline2 != null) {
                    var value = ko.mapping.toJS(data);
                    if (!self.onSaveInline2(value, data)) {
                        self.errors.showAllMessages();
                        return false;
                    }
                }

                self.errors.showAllMessages();
            }
        }

        self.saveInlineEditingRow = function () {
            if (_isInlineEdit) {
                self.saveInline(self.editingRowIndex(),
                                self.selectedItem());
            }
        }

        self.saveInlineEditingRow2 = function () {
            if (_isInlineEdit) {
                return self.saveInline2(self.editingRowIndex(),
                                self.selectedItem());
            }
        }


        self.saveInlineWithPopulatedValue = function (value) {
            if (_isInlineEdit) {
                if (self.onSaveInline != null)
                    self.onSaveInline(value);

                self.listDataItems.replace(self.listDataItems()[self.editingRowIndex()], value);

                self.editingRowIndex(-1);
                self.isCreateNewInline(false);
            }
        }

        // delegate for inline saving
        self.onSaveInline = null;

        self.cancelInline = function (item) {
            if (_isInlineEdit) {
                if (!self.isCreateNewInline()) {
                    if (_originalEditObject != null)
                        self.listDataItems.replace(self.listDataItems()[self.editingRowIndex()], _originalEditObject);

                    self.editingRowIndex(-1);
                    self.errors = null;
                }
                else {
                    if (item == null)
                        item = self.selectedItem();
                    self.listDataItems.remove(item);
                    self.editingRowIndex(-1);
                    self.selectedRowIndex(0);
                    self.isCreateNewInline(false);

                    //remove validation for item
                    self.errors = null;
                }
            }
        }

        self.addNewInline = function (data) {
            if (_isInlineEdit && self.editingRowIndex() === -1) {

                //apply validation rules
                var obsvObj = self.mapping == null ? ko.mapping.fromJS(data) : ko.mapping.fromJS(data, self.mapping);

                self.errors = ko.validation.group(obsvObj);
                if (self.applyValidationRules != null) self.applyValidationRules(obsvObj);

                //self.lastPage();
                self.listDataItems.push(obsvObj);
                self.editingRowIndex(self.listDataItems().length - 1);
                self.selectedRowIndex(self.editingRowIndex());
                self.isCreateNewInline(true);

                return obsvObj;
            }
        }

        self.getEditingRowData = function () {
            if (_isInlineEdit && self.listDataItems != null)
                return ko.mapping.toJS(self.listDataItems[self.editingRowIndex]);
        }

        /*
        *  css functions
        */
        self.sortCss = function (column, expression, order) {
            if (column === expression) {
                if (order === 'ASC')
                    return 'ui-icon sorting_asc';
                else
                    return 'ui-icon sorting_desc';
            } else {
                return 'ui-icon sorting';
            }
        }


        self.reset = function () {
            self.listDataItems([]);
            //self.active(false);
            self.editingRowIndex(-1);

            self.totalPages(0);
            self.totalRecords(-1);

            self.currentPageIndex(1);
            self.selectedRowIndex(0);

            //self.selectedPageSize = ko.observable(_criteria.PageSize);
            self.isCreateNewInline = ko.observable(false);
            self.errors = null;
        }

        /*
        * private functions
        */
        function loadData(callback) {
            //load data
            $.ajax({
                url: _dataSourceUrl,
                type: 'POST',
                contentType: 'application/json',
                data: ko.toJSON(_criteria),
                cache: false,
                success: function (data) {
                    if (data != null) {
                        if (data.Results != null)
                            self.listDataItems(data.Results)
                        else
                            self.listDataItems([]);

                        self.totalPages(data.TotalPages);
                        self.totalRecords(data.TotalRecords);

                        self.active(true);
                        self.errors = null;

                        if (callback) callback();
                    }
                }
            });
        }
    }
})(this.app = this.app || {}, jQuery);

