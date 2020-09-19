(function () {

    angular.module('RequestPostingApp', []);

    angular.module('RequestPostingApp')
.controller('RequestController', RequestController);

    function RequestController() {
        var reg = this;
        reg.position.dateEnd = $("#dateEnd").val();
        reg.position.dateStart = $("#dateStart").val();
        reg.position.btc = $("#TextBTC").val();
        reg.position.title = $("#TextPositionTitle").val();
        reg.submit = function () {
        reg.completed = true;
        };
    }

})();
