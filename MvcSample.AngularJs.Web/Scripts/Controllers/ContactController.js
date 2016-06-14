var ContactController = function($scope, contactService) {
    $scope.newcontact = {
        id: 0,
        name: "",
        mobile: "",
        email: ""
    };

    getContacts();

    function getContacts() {
        contactService.getContacts().success(function (contacts) {
            $scope.contacts = contacts;
            console.log($scope.contacts);
        })
            .error(function (error) {
            debugger;
                $scope.status = 'Unable to load contacts ' + error.message;
                console.log($scope.status);
            });
    }

    //Can't use DeferredObject here because the HTML is already provided and isn't loaded from a partial view.
    //function getContacts() {
    //    var result = ContactService.getContacts();
    //    result.then(function(contacts) {
    //        if (contacts != null) {
    //            $scope.contacts = contacts;
    //            console.log($scope.contacts);
    //        } else {
    //            console.log("Contact Controller: Contacts are null!");
    //        }
    //    });
    //};

    $scope.saveContact = function() {
        contactService.createOrUpdateContact($scope.newcontact).success(function () {
                alert("Contact saved, page will now refresh.");
                window.location.href = "/contact/index";
            }
        ).error(function(error) {
            alert("An error occurred while saving the contact. " + error);
        });
    };

    $scope.edit = function(contactId) {
        contactService.getContactById(contactId).success(function(contact) {
            $scope.newcontact = contact;
        });
    };

    $scope.delete = function(contactId) {
        contactService.deleteContact(contactId).success(function() {
                alert("Contact Deleted, page will now refresh.");
                window.location.href = "/contact/index";
            }
        ).error(function(error) {
            alert("An error occurred while deleting the contact. " + error);
        });
    };
};

ContactController.$inject = ['$scope', 'ContactService'];