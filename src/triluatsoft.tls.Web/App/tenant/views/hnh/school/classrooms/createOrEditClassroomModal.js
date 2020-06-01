(function () {
    appModule.controller('tenant.views.hnh.school.classrooms.createOrEditClassroomModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.classroom', 'classroomId',
        function ($scope, $uibModalInstance, classroomService, classroomId) {
            var vm = this;

            vm.saving = false;
            vm.classroom = {};

            vm.typeOptions = [
                { id: 0, name: app.localize('PleaseSelect') },
                { id: 1, name: app.localize('ClassroomType_Basic') },
                { id: 2, name: app.localize('ClassroomType_Advance') }
            ];

            function init() {
                if (classroomId) {
                    classroomService.getClassroom({
                        id: classroomId
                    }).then(function (result) {
                        var temp = result.data;
                        temp.classroomTypeSelected = { id: result.data.classroomType, name: getClassroomTypeAsString(result.data.classroomType) };
                        vm.classroom = temp;
                    });
                } else {
                    vm.classroom.classroomTypeSelected = { id: 0, name: app.localize('PleaseSelect') };
                }
            }

            function getClassroomTypeAsString(typeAsNumber) {
                switch (typeAsNumber) {
                    case 1:
                        return app.localize('ClassroomType_Basic');
                    case 2:
                        return app.localize('ClassroomType_Advance');
                    default:
                        return app.localize('PleaseSelect');
                }
            }

            vm.save = function () {
                vm.saving = true;

                var classroomInput = vm.classroom;
                classroomInput.classroomType = vm.classroom.classroomTypeSelected.id;

                classroomService.createOrUpdateClassroom(classroomInput).then(function () {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                }).finally(function () {
                    vm.saving = false;
                });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss();
            };

            init();
        }
    ]);
})();