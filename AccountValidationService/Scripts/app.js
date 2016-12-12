﻿var ViewModel = function () {
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



    self.accountDetails = ko.observable();


    self.mail = ko.observable();
    self.username = ko.observable();
    self.iban = ko.observable();

    self.getAccountDetails = function () {
        

        ajaxHelper('/api/accounts?email=' + self.mail() + '&username=' + self.username() + '&iban=' + self.iban(), 'GET').done(function (data) {
            self.accountDetails(data);


        });
    };

    // Fetch the initial data.
    getAllAccounts();
};

ko.applyBindings(new ViewModel());