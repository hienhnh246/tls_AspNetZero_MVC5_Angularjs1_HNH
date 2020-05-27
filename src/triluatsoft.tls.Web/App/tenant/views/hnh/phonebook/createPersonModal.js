(function () {
    appModule.controller('tenant.views.hnh.phonebook.createPersonModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.person',
        function ($scope, $uibModalInstance, personService) {
            var vm = this;

            vm.saving = false;
            vm.person = {};

            vm.save = function () {
                vm.saving = true;
                personService.createPerson(vm.person).then(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };
        }
    ]);
})();