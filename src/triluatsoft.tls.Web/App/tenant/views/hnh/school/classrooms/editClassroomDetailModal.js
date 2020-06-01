(function () {
    appModule.controller('tenant.views.hnh.school.classrooms.editClassroomDetailModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.classroom', 'abp.services.app.student', 'abp.services.app.studentAndClassroom', 'classroomId',
        function ($scope, $uibModalInstance, classroomService, studentService, studentAndClassroomService, classroomId) {
            var vm = this;

            vm.saving = false;
            vm.studentLoading = false;
            vm.classroom = {};
            vm.students = [];
            vm.filterStudentText = null;
            vm.pagedParams = {
                maxResultCount: 10,
                maxSize: 5,
                maxResultCountOfUibPagination: 10
            };
            vm.currentStudentPage = 1;
            vm.totalUibPaginationStudents = null;

            vm.typeOptions = [
                { id: 0, name: app.localize('PleaseSelect') },
                { id: 1, name: app.localize('ClassroomType_Basic') },
                { id: 2, name: app.localize('ClassroomType_Advance') }
            ];

            function init() {
                classroomService.getClassroom({
                    id: classroomId
                }).then(function (result) {
                    var temp = result.data;
                    temp.classroomTypeSelected = { id: result.data.classroomType, name: getClassroomTypeAsString(result.data.classroomType) };
                    vm.classroom = temp;
                }).finally(function () {
                    vm.getStudentsPagination();
                });       
            }

            vm.getStudentsPagination = function () {
                vm.studentLoading = true;

                studentService.getStudentsPagination({
                    filter: vm.filterStudentText,
                    skipCount: (vm.currentStudentPage - 1) * vm.pagedParams.maxResultCount,
                    maxResultCount: vm.pagedParams.maxResultCount
                }).then(function (result) {
                    var totalStudents = result.data.totalCount;

                    vm.students = checkStudentsInClassroom(result.data.items);
                    vm.totalStudents = totalStudents;
                    vm.totalUibPaginationStudents = (totalStudents / vm.pagedParams.maxResultCount) * vm.pagedParams.maxResultCountOfUibPagination;
                }).finally(function () {
                    vm.studentLoading = false;
                });
            };

            vm.studentPageChanged = function () {
                vm.getStudentsPagination();
            };

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

            function checkStudentsInClassroom(students) {
                var result = [];

                for (i = 0; i < students.length; i++) {
                    var student = students[i];
                    var studentsAndClassrooms = students[i].studentsAndClassrooms;

                    if (studentsAndClassrooms.length == 0) {
                        student.attended = 0;
                    }

                    for (j = 0; j < studentsAndClassrooms.length; j++) {
                        if (studentsAndClassrooms[j].classroomId == vm.classroom.id) {
                            student.attended = 1;
                            break;
                        } else {
                            student.attended = 0;
                        }
                    }

                    result.push(student);
                }

                return result;
            }

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

            vm.addStudentToClassroom = function (student, classroom) {
                if (classroom.maxStudentAmount < classroom.studentsAndClassrooms.length) {
                    abp.message.warn(app.localize('WarnEnoughStudentAmountOfClassroom'));
                    return;
                }

                abp.message.confirm(
                    app.localize('AreYouSureToAddStudentToClassroom', student.name, classroom.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            studentAndClassroomService.createStudentAndClassroom({
                                classroomId: classroom.id,
                                studentId: student.id
                            }).then(function () {
                                abp.notify.success(app.localize('SuccessfullyAdded'));
                                init();
                            });
                        }
                    }
                );
            };

            vm.removeStudentFromClassroom = function (student, classroom) {
                abp.message.confirm(
                    app.localize('AreYouSureToRemoveStudentFromClassroom', student.name, classroom.name),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            var studentsAndClassrooms = student.studentsAndClassrooms;
                            var studentAndClassroomId = null;

                            for (i = 0; i < studentsAndClassrooms.length; i++) {
                                if (studentsAndClassrooms[i].classroomId == classroom.id && studentsAndClassrooms[i].studentId == student.id) {
                                    studentAndClassroomId = studentsAndClassrooms[i].id;
                                }
                            }

                            studentAndClassroomService.deleteStudentAndClassroom({
                                id: studentAndClassroomId
                            }).then(function () {
                                abp.notify.success(app.localize('SuccessfullyRemoved'));
                                init();
                            });
                        }
                    }
                );
            };

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
                $uibModalInstance.close();
            };

            init();
        }
    ]);
})();