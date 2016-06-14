var ContactService = function($http) {
    this.getContacts = function () {
        return $http.get('/Contact/GetContacts');
        //Can't use DeferredObject here because the HTML is already provided and isn't loaded from a partial view.
        //var de = $q.defer();
        //$http.get('/Contact/GetContacts').
        //    success(function(data) {
        //        de.resolve({ contacts: data });
        //    });
        //return de.promise;
    };

    this.getContactById = function (contactId) {
        return $http.get('/Contact/GetContact/' + contactId);
    };
    
    this.createOrUpdateContact = function (contact) {
        if (contact.id == 0)
            return addContact(contact);
        else {
            return updateContact(contact.id, contact);
        }
    };

    this.deleteContact = function (contactId) {
        return $http({
            method: "delete",
            url: "/Contact/DeleteContact/" + contactId
        });
    };

    function addContact(contact) {
        return $http({
            method: "post",
            url: "/Contact/AddContact",
            data: JSON.stringify(contact),
            dataType: "json"
        });
    };

    function updateContact (contactId, contact) {
        return $http({
            method: "put",
            url: "/Contact/UpdateContact/" + contactId,
            data: JSON.stringify(contact),
            dataType: "json"
        });
    };



};
ContactService.$inject = ['$http'];