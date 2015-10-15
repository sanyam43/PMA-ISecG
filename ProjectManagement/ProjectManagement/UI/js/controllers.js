app.controller("ProjectController", function ($scope, angularService) {
    $scope.divProject = false;
    GetAllProject();
    //To Get All Records  
    function GetAllProject() {
        $http.get('api/project').success(function (result, status, headers) {
           
            
            var getData = angular.copy(result); }).error(function () {
                alert("error");

            });
        getData.then(function (proj) {
            $scope.projects = proj.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editProject = function (project) {
        var getData = angularService.getProject(project.Id);
        getData.then(function (proj) {
            $scope.project = proj.data;
            $scope.projectId = project.projectId;
            $scope.projectName = project.projectName;
            $scope.projectCode = project.projectCode;
            $scope.Action = "Update";
            $scope.divProject = true;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdateProject = function () {
        var Project = {
            Name: $scope.projectName,
            Code: $scope.projectCode,

        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Project.Id = $scope.projectId;
            var getData = angularService.updateProj(Project);
            getData.then(function (msg) {
                GetAllProject();
                alert(msg.data);
                $scope.divProject = false;
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getData = angularService.AddProj(Project);
            getData.then(function (msg) {
                GetAllProject();
                alert(msg.data);
                $scope.divProject = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.AddProjectDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divProject = true;
    }

    $scope.deleteProject = function (project) {
        var getData = angularService.DeleteProj(project.projectId);
        getData.then(function (msg) {
            GetAllProject();
            alert('Project Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.projectId = "";
        $scope.projectName = "";
        $scope.projectCode = "";
    }
});