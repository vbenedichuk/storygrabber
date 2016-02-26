//******************************************************************
// Rest api wrapper.
//******************************************************************


function RestWrapper() {
    var self = this;
}

RestWrapper.prototype.getData = function (year, month, day, callback) {
    if (day == null) {
        var url = "/api/Calendar/";
        if (year != null) {
            url += "?year=" + year;
            if (month != null) {
                url += "&month=" + month;
            }
        }
        $.getJSON(url, callback);
    }
    else {
        var url = "/api/Stories/?date=" + year + "-" + month + "-" + day
        $.getJSON(url, callback);
    }
}

//******************************************************************
// Main page model
//******************************************************************
function MainPageModel() {
    var self = this;
    self.years = ko.observableArray([]);
    self.selectedYear = ko.observable(null);
    self.selectedMonth = ko.observable(null);
    self.selectedDay = ko.observable(null);
}

MainPageModel.prototype.select = function (year, month, day) {
    var self = this;
    self.selectedYear(year);
    self.selectedMonth(month);
    self.selectedDay(day);
}

MainPageModel.prototype.initialize = function () {
    var self = this;
    ko.applyBindings(self, $("#yearsList").get(0));

    restApi.getData(null, null, null, function (data) {
        var items = [];
        $.each(data, function (key, val) {
            items.push(new Year(val, self));
        });
        self.years(items);
    });
}

//******************************************************************
// Year model
//******************************************************************
function Year(data, parent) {
    var self = this;
    self.year = ko.observable(data);
    self.months = ko.observableArray([]);
    self.expanded = ko.observable(false);
    self.loaded = ko.observable(false);
    self.parent = parent;
}

Year.prototype.load = function () {
    var self = this;
    restApi.getData(self.year(), null, null, function (data) {
        var items = [];
        $.each(data, function (key, val) {
            items.push(new Month(val, self.year(), self));
        });
        self.months(items);
        self.loaded(true);
    });
}

Year.prototype.toggle = function () {
    var self = this;
    if (!self.expanded() && !self.loaded()) {
        self.load();
    }
    self.expanded(!self.expanded());
    if (self.expanded()) {
        self.parent.select(self, null, null);
    }
    else {
        self.parent.select(null, null, null);
    }
}

Year.prototype.select = function (month, day) {
    var self = this;
    self.parent.select(self, month, day);
}

//******************************************************************
// Month model
//******************************************************************
function Month(data, year, parent) {
    var self = this;
    self.parent = parent;
    self.year = ko.observable(year);
    self.month = ko.observable(data);
    self.days = ko.observableArray([]);
    self.expanded = ko.observable(false);
    self.loaded = ko.observable(false);
    self.name = ko.computed(function () {
        switch (self.month()) {
            case 1: return "Январь"; break;
            case 2: return "Февраль"; break;
            case 3: return "Март"; break;
            case 4: return "Апрель"; break;
            case 5: return "Май"; break;
            case 6: return "Июнь"; break;
            case 7: return "Июль"; break;
            case 8: return "Август"; break;
            case 9: return "Сентябрь"; break;
            case 10: return "Октябрь"; break;
            case 11: return "Ноябрь"; break;
            case 12: return "Декабрь"; break;
        }
    });
}

Month.prototype.load = function () {
    var self = this;
    restApi.getData(self.year(), self.month(), null, function (data) {
        var items = [];
        $.each(data, function (key, val) {
            items.push(new Day(val, self.month(), self.year(), self));
        });
        self.days(items);
        self.loaded(true);
    });
}

Month.prototype.toggle = function () {
    var self = this;
    if (!self.expanded() && !self.loaded()) {
        self.load();
    }
    self.expanded(!self.expanded());
    if (self.expanded()) {
        self.parent.select(self, null);
    }
    else {
        self.parent.select(null, null);
    }
}

Month.prototype.switch = function () {
    var self = this;
    self.expanded(!self.expanded());
}

Month.prototype.select = function (day) {
    var self = this;
    self.parent.select(self, day);
}

//******************************************************************
// Day model
//******************************************************************
function Day(data, month, year, parent) {
    var self = this;    
    self.parent = parent;
    self.year = ko.observable(year);
    self.month = ko.observable(month);
    self.day = ko.observable(data);
    self.stories = ko.observableArray([]);
    self.expanded = ko.observable(false);
    self.loaded = ko.observable(false);
}

Day.prototype.load = function () {
    var self = this;

    restApi.getData(self.year(), self.month(), self.day(), function (data) {
        var items = [];
        $.each(data, function (key, val) {
            items.push(new Story(val));
        });
        self.stories(items);
        self.loaded(true);
    });
}

Day.prototype.toggle = function () {
    var self = this;
    if (!self.expanded() && !self.loaded()) {
        self.load();
    }
    self.expanded(!self.expanded());
    if (self.expanded()) {
        self.parent.select(self);
    }
    else {
        self.parent.select(null);
    }
}

Day.prototype.switch = function () {
    var self = this;
    self.expanded(!self.expanded());
}

//******************************************************************
// Story model
//******************************************************************
function Story(data) {
    var self = this;
    self.id = ko.observable(data.Id);
    self.date = ko.observable(data.Date);
    self.title = ko.observable(data.Title);
    self.text = ko.observable(data.Text);
}
