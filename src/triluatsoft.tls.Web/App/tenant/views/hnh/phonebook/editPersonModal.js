(function () {
    appModule.controller('tenant.views.hnh.phonebook.editPersonModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.person', 'personId',
        function ($scope, $uibModalInstance, personService, personId) {
            var vm = this;

            vm.saving = false;
            vm.person = {};

            vm.typeOptions = [
                { id: 0, name: app.localize('PhoneType_Mobile') },
                { id: 1, name: app.localize('PhoneType_Home') },
                { id: 2, name: app.localize('PhoneType_Business') }
            ];

            vm.init = function () {
                personService.getPersonForEdit({
                    id: personId
                }).then(function (result) {
                    var temp = {};
                    temp.id = result.data.id;
                    temp.name = result.data.name;
                    temp.surname = result.data.surname;
                    temp.emailAddress = result.data.emailAddress;
                    temp.phones = convertNumberStringToInt(result.data.phones);
                    vm.person = temp;
                });
            };

            function convertNumberStringToInt(phones) {
                var result = [];

                for (i = 0; i < phones.length; i++) {
                    var temp = {};
                    temp.id = phones[i].id;
                    temp.personId = phones[i].personId;
                    temp.type = phones[i].type;
                    temp.typeSelect = { id: phones[i].type, name: getPhoneTypeAsString(phones[i].type) };
                    temp.number = parseInt(phones[i].number);
                    result.push(temp);
                }

                return result;
            }

            function getPhoneTypeAsString(typeAsNumber) {
                switch (typeAsNumber) {
                    case 0:
                        return app.localize('PhoneType_Mobile');
                    case 1:
                        return app.localize('PhoneType_Home');
                    case 2:
                        return app.localize('PhoneType_Business');
                    default:
                        return '?';
                }
            }

            vm.editPhone = function (phone, person) {
                if (!phone || !phone.type || !phone.number) {
                    abp.message.warn(app.localize('WarnPhoneInput'));
                    return;
                }

                phone.personId = person.id;
                phone.type = phone.typeSelect.id;

                personService.editPhone(phone).then(function () {
                    abp.notify.success(app.localize('SavedSuccessfully'));
                }).finally(function () {
                    vm.init();
                });
            };

            vm.deletePhone = function (phone, person) {
                abp.message.confirm(
                    app.localize('AreYouSureToDeletePhone', phone.number),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            personService.deletePhone({
                                id: phone.id
                            }).then(function () {
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                                person.phones = _.without(person.phones, phone);
                            });
                        }
                    }
                );
            };

            vm.save = function (personInput) {
                vm.saving = true;
                var person = personInput;
                var phones = [];
                for (i = 0; i < personInput.phones.length; i++) {
                    var phone = {};
                    phone.type = personInput.phones[i].typeSelect.id;
                    phone.id = personInput.phones[i].id;
                    phone.number = personInput.phones[i].number;
                    phone.personId = personInput.phones[i].personId;

                    phones.push(phone);
                }

                person.phones = phones;

                personService.editPerson(person).then(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            vm.init();
        }
    ]);
})();