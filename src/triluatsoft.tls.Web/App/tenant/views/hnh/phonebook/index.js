(function () {
    appModule.controller('tenant.views.hnh.phonebook.index', [
        '$scope', '$uibModal', 'abp.services.app.person',
        function ($scope, $uibModal, personService) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;            
            vm.filterText = null;
            vm.persons = [];
            vm.personPage = [];
            vm.editingPhone = null;

            vm.permissions = {
                createPerson: abp.auth.hasPermission('Pages.Tenant.PhoneBook.CreatePerson'),
                editPerson: abp.auth.hasPermission('Pages.Tenant.PhoneBook.EditPerson'),
                deletePerson: abp.auth.hasPermission('Pages.Tenant.PhoneBook.DeletePerson')
            };

            function getPeople() {
                vm.loading = true;

                personService.getPeople({}).then(function (result) {
                    vm.persons = result.data.items;
                }).finally(function () {
                    vm.loading = false;
                });
            }

            vm.getPeople = function () {
                personService.getPeople({
                    filter: vm.filterText
                }).then(function (result) {
                    vm.persons = result.data.items;
                });
            };

            function getPeoplePagination() {
                vm.loading = true;
                vm.personPage.personPageNum = 1;
                vm.personPage.maxResultCount = 5;

                personService.getPeoplePagination({
                    skipCount: (vm.personPage.personPageNum - 1) * vm.personPage.maxResultCount,
                    maxResultCount: vm.personPage.maxResultCount
                }).then(function (result) {
                    vm.persons = result.data.items;
                    vm.personPage.totalPerson = result.data.totalCount;
                    vm.personPage.totalPersonPage = Math.ceil(result.data.totalCount / vm.personPage.maxResultCount);
                }).finally(function () {
                    vm.loading = false;
                });
            }

            vm.getPeoplePagination = function () {
                personService.getPeoplePagination({
                    filter: vm.filterText,
                    skipCount: (vm.personPage.personPageNum - 1) * vm.personPage.maxResultCount,
                    maxResultCount: vm.personPage.maxResultCount
                }).then(function (result) {
                    vm.persons = result.data.items;
                    vm.personPage.totalPerson = result.data.totalCount;
                    vm.personPage.totalPersonPage = Math.ceil(result.data.totalCount / vm.personPage.maxResultCount);
                });
            };

            vm.nextPersonPage = function () {
                if (vm.personPage.personPageNum < vm.personPage.totalPersonPage) {
                    vm.personPage.personPageNum = vm.personPage.personPageNum + 1;
                    vm.getPeoplePagination();
                }
            };

            vm.backPersonPage = function () {
                if (vm.personPage.personPageNum > 1) {
                    vm.personPage.personPageNum = vm.personPage.personPageNum - 1;
                    vm.getPeoplePagination();
                }
            };

            vm.openCreatePersonModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/hnh/phonebook/createPersonModal.cshtml',
                    controller: 'tenant.views.hnh.phonebook.createPersonModal as vm',
                    backdrop: 'static'
                });

                modalInstance.result.then(function () {
                    getPeoplePagination();
                });
            };   

            vm.openEditPersonModal = function (personId) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/hnh/phonebook/editPersonModal.cshtml',
                    controller: 'tenant.views.hnh.phonebook.editPersonModal as vm',
                    backdrop: 'static',
                    resolve: {
                        personId: function () {
                            return personId;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    getPeoplePagination();
                });
            };  

            vm.deletePerson = function (person) {
                abp.message.confirm(
                    app.localize('AreYouSureToDeletePerson', person.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            personService.deletePerson({
                                id: person.id
                            }).then(function () {
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                                getPeoplePagination();
                            });
                        }
                    }
                );
            };

            vm.phoneDetail = function (person) {
                if (person == vm.editingPhone) {
                    vm.editingPhone = null;
                } else {
                    vm.editingPhone = person;
                }
            };

            vm.getPhoneTypeAsString = function (typeAsNumber) {
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
            };

            vm.deletePhone = function (phone, person) {
                personService.deletePhone({
                    id: phone.id
                }).then(function () {
                    abp.notify.success(app.localize('SuccessfullyDeleted'));
                    person.phones = _.without(person.phones, phone);
                });
            };

            vm.addPhone = function (phone, person) {
                if (!phone || !phone.type || !phone.number) {
                    abp.message.warn(app.localize('WarnPhoneInput'));
                    return;
                }

                phone.personId = person.id;

                personService.addPhone(phone)
                    .then(function (result) {
                        abp.notify.success(app.localize('SavedSuccessfully'));
                        person.phones.push(result.data);
                        phone.number = '';
                    });
            };

            getPeoplePagination();
        }
    ]);
})();