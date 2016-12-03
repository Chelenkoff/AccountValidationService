var ViewModel = function () {
    var self = this;
    self.accounts = ko.observableArray();
    self.error = ko.observable();

    var accountsUri = '/api/accounts/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllAccounts() {
        ajaxHelper(accountsUri, 'GET').done(function (data) {
            self.accounts(data);
        });
    }

    // Fetch the initial data.
    getAllAccounts();
};

ko.applyBindings(new ViewModel());