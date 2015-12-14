var BankAccountApp = angular.module("BankAccountApp", ["ngResource", "ngRoute"]);

BankAccountApp.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/register/', {
            templateUrl: "templates/register.html",
            controller: 'registerCtrl',
        })
        .otherwise({
            template: 'doesnt exist'
       });
});

BankAccountApp.factory('Register', function ($resource) {
    return $resource('api/RegisterController/Post');
});

BankAccountApp.controller('registerCtrl', [
    '$scope',
    function registerCtrl($scope) {
        $scope.regiser = function(name, pass) {
            $scope.result = Register.Post({ username: name, password: pass });
        }
    }
]);