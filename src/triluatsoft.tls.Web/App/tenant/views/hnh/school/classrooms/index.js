(function () {
    appModule.controller('tenant.views.hnh.school.classrooms.index', [
        '$scope', '$uibModal', 'abp.services.app.classroom',
        function ($scope, $uibModal, classroomService) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.classroomLoading = false;
            vm.studentLoading = false;
            vm.classrooms = [];
            vm.studentsOfClassroom = [];
            vm.totalClassrooms = null;
            vm.totalUibPaginationClassrooms = null;
            vm.totalStudentsOfClassroom = null;
            vm.totalUibPaginationStudentsOfClassroom = null;
            vm.filterClassroomText = null;
            vm.filterStudentTextOfClassroom = null;
            vm.pagedParams = {
                maxResultCount: 5,
                maxSize: 5,
                maxResultCountOfUibPagination: 10
            };
            vm.currentClassroomPage = 1;
            vm.currentStudentOfClassroomPage = 1;

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
                            });
                        }
                    }
                );
            };

            vm.getClassroomsPagination();
        }
    ]);
})();