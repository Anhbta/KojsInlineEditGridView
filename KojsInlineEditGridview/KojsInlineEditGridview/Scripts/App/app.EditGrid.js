(function (app) {

    app.EditGrid = function () {
        var self = this;



        self.gridView = new app.GridViewModel({
            Criteria: { PageSize: 10, PageIndex: 1, SortExpression: "", SortDirection: "" },
            DataSourceUrl: '/api/ApiUsers/GetUsers',
            InlineEdit: true
        });

        self.gridView.applyValidationRules = function (user) {
            //user is observable object
            user.UserId.extend({ required: true });
            user.DateOfBirth.extend({ date: true });
            user.Email.extend({email: true});
        }

        self.gridView.onSaveInline = function (entity) {
            //ajax call to persist to server db
            alert(entity.UserId + " is saved");
        }

        self.gridView.onDelete = function (entity) {
            //ajax call to delete item in server side
            alert(entity.UserId + " is deleted");
            //reload the page call search
        }

        self.createNew = function () {
            var entity = {
                UserId: '',
                UserName: '',
                DateOfBirth: '',
                PhoneNumber: '',
                Email: '',
                MarritalStatus: '',
                Address:'',
            };

            self.gridView.addNewInline(entity);
        }
        

        self.marritalStatuses = ko.observableArray(['Single','Married','Divorced']);

        //load data
        self.search = function () {
            self.gridView.search({});
        }

        self.search();
    }

    ko.applyBindings(new app.EditGrid());

})(app = this.app || {});
