
//******************************************************************
// Startup code
//******************************************************************
var model;
var restApi;

$(function () {
    restApi = new RestWrapper();
    model = new MainPageModel();
    model.initialize();
});