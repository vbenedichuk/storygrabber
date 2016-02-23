

function MainPageModel() {

}

MainPageModel.prototype.initialize = function () {
    
}

function Story(data) {
    var self = this;
    self.id = ko.observable(data.Id);
    self.date = ko.observable(data.Date);
    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
}

var model;

$(function () {
    model = new MainPageModel();
    model.initialize();
});