'use strict';

var tas = angular.module('services', []);


//tas.service('MyService', function ($http) {
//    var myData = null;

//    var promise = $http.get('/api/v1/testv2').success(function (result, status, headers) {
//        myData = result;
//    });

//    return {
//        promise: promise,
//        setData: function (data) {
//            myData = data;
//        },
//        doStuff: function () {
//            return myData;//.getSomeData();
//        }
//    };
//});




tas.factory('Auth', function ($http, $cookieStore, $rootScope) {

    var accessLevels = routingConfig.accessLevels
        , userRoles = routingConfig.userRoles
        , currentUser = $cookieStore.get('user') || { username: '', role: userRoles.user };

    var uname = currentUser.username;
    $rootScope.loggedUserName = uname;
    //alert("-" + uname + "-");
    //$cookieStore.put("username", uname);
    //alert("Nice to meet you " + currentUser.username);


    //$cookieStore.remove('user');

    function changeUser(user) {
        _.extend(currentUser, user);
    };

    return {
        authorize: function (accessLevel, role) {
            if (role === undefined)
                role = currentUser.role;

            return accessLevel.bitMask & role.bitMask;
        },
        isLoggedIn: function (user) {
            if (user === undefined)
                user = currentUser;
            return user.role.title == userRoles.user.title || user.role.title == userRoles.admin.title;
        },
        register: function (user, success, error) {
            $http.post('/register', user).success(function (res) {
                changeUser(res);
                success();
            }).error(error);
        },
        login: function (user, success, error) {
            $http.post('/login', user).success(function (user) {
                changeUser(user);
                success(user);
            }).error(error);
        },
        logout: function (success, error) {
            $http.post('/logout').success(function () {
                changeUser({
                    username: '',
                    role: userRoles.public
                });
                success();
            }).error(error);
        },
        accessLevels: accessLevels,
        userRoles: userRoles,
        user: currentUser
    };
});

//tas.factory('Users', function($http) {
//    return {
//        getAll: function(success, error) {
//            $http.get('/users').success(success).error(error);
//        }
//    };
//});
