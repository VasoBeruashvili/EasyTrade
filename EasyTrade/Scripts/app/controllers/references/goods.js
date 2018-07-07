var app = angular.module('goods-app', ['ui.bootstrap']);

app.controller('goods-ctrl', function ($scope, $uibModal) {

    $scope.openGoodsModal = function (id) {
        var modalInstance = $uibModal.open({
            animation: false,
            templateUrl: '../../templates/references/add_or_edit_good.html',
            size: 'lg',
            backdrop: 'static'
        });
    }


});