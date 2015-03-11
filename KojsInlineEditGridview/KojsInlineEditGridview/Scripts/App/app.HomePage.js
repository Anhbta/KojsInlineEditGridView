(function (app) {
    
    app.HomePage = function () {
        var self = this;

        self.gridView = new app.GridViewModel({
            Criteria: { PageSize: 10, PageIndex: 1, SortExpression: "", SortDirection: "" },
            DataSourceUrl: 'api/ApiUsers/GetUsers',
            InlineEdit: true
        });

        //load data
        self.search = function () {
            self.gridView.search({});
        }

        self.search();
    }

    ko.applyBindings(new app.HomePage());
    
})(app = this.app || {});
