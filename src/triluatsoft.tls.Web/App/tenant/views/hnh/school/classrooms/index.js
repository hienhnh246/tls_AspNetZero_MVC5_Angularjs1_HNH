(function () {
    appModule.controller('tenant.views.hnh.school.classrooms.index', [
        '$scope', '$uibModal', 'abp.services.app.classroom', 'abp.services.app.student',
        function ($scope, $uibModal, classroomService, studentService) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.classroomLoading = false;
            vm.studentLoading = false;
            vm.classrooms = [];
            vm.studentsInClassroom = [];
            vm.totalClassrooms = null;
            vm.totalUibPaginationClassrooms = null;
            vm.filterClassroomText = null;
            vm.pagedParams = {
                maxResultCount: 5,
                maxSize: 5,
                maxResultCountOfUibPagination: 10
            };
            vm.currentClassroomPage = 1;
            vm.classroomSelected = null;

            function getClassrooms() {
                vm.classroomLoading = true;

                classroomService.getAllClassroom().then(function (result) {
                    vm.classrooms = result.data.items;
                }).finally(function () {
                    vm.classroomLoading = false;
                });
            }

            vm.getClassroomsPagination = function () {
                vm.classroomLoading = true;

                classroomService.getClassroomsPagination({
                    filter: vm.filterClassroomText,
                    skipCount: (vm.currentClassroomPage - 1) * vm.pagedParams.maxResultCount,
                    maxResultCount: vm.pagedParams.maxResultCount
                }).then(function (result) {
                    var totalClassrooms = null;

                    vm.classrooms = result.data.items;
                    totalClassrooms = result.data.totalCount;
                    vm.totalClassrooms = totalClassrooms;
                    vm.totalUibPaginationClassrooms = (totalClassrooms / vm.pagedParams.maxResultCount) * vm.pagedParams.maxResultCountOfUibPagination;
                }).finally(function () {
                    vm.classroomLoading = false;
                });
            };

            vm.classroomPageChanged = function () {
                vm.getClassroomsPagination();
            };

            function openCreateOrEditClassroomModal(classroom) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/hnh/school/classrooms/createOrEditClassroomModal.cshtml',
                    controller: 'tenant.views.hnh.school.classrooms.createOrEditClassroomModal as vm',
                    backdrop: 'static',
                    resolve: {
                        classroomId: classroom.id
                    }
                });

                modalInstance.result.then(function () {
                    vm.getClassroomsPagination();
                });
            }

            vm.openCreateClassroomModal = function () {
                openCreateOrEditClassroomModal({});
            };

            vm.openEditClassroomModal = function (classroom) {
                openCreateOrEditClassroomModal(classroom);
            };

            vm.deleteClassroom = function (classroom) {
                abp.message.confirm(
                    app.localize('AreYouSureToDeleteClassroom', classroom.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            classroomService.deleteClassroom({
                                id: classroom.id
                            }).then(function () {
                                abp.notify.success(app.localize('SuccessfullyDeleted'));
                                vm.getClassroomsPagination();
                            }).finally(function () {
                                if (vm.classroomSelected.id == classroom.id) {
                                    vm.classroomSelected = null;
                                }
                            });
                        }
                    }
                );
            };

            vm.rowClassroomHighlighted = function (classroom) {
                vm.classroomSelected = classroom;
                vm.getStudentsInClassroom(classroom);
                //getClassPresidentOfClassroom();
            };

            vm.getClassroomTypeAsString = function (typeAsNumber) {
                switch (typeAsNumber) {
                    case 1:
                        return app.localize('ClassroomType_Basic');
                    case 2:
                        return app.localize('ClassroomType_Advance');
                    default:
                        return app.localize('NoSelectedYet');
                }
            };

            vm.getStudentsInClassroom = function (classroom) {
                vm.studentLoading = true;

                studentService.getStudentsInClassroom(classroom.id)
                    .then(function (result) {
                        vm.studentsInClassroom = result.data.items;
                    }).finally(function () {
                        vm.studentLoading = false;
                    });
            };

            vm.getGenderAsString = function (genderAsNumber) {
                switch (genderAsNumber) {
                    case 1:
                        return app.localize('Male');
                    case 2:
                        return app.localize('Female');
                    default:
                        return '?';
                }
            };

            vm.openEditClassroomDetailModal = function (classroom) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/tenant/views/hnh/school/classrooms/editClassroomDetailModal.cshtml',
                    controller: 'tenant.views.hnh.school.classrooms.editClassroomDetailModal as vm',
                    backdrop: 'static',
                    resolve: {
                        classroomId: classroom.id
                    }
                });

                modalInstance.result.then(function () {
                    vm.getClassroomsPagination();
                    vm.getClassroomSelected(vm.classroomSelected.id);
                    vm.getStudentsInClassroom(vm.classroomSelected);
                });
            }

            vm.getClassroomSelected = function (classroomId) {
                classroomService.getClassroom({
                    id: classroomId
                }).then(function (result) {
                    vm.classroomSelected = result.data;
                });
            };

            vm.getClassroomsPagination();
        }
    ]);
})();