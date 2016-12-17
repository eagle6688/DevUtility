$(function () {
    $('#myKo').koHelper({
        url: '/Handlers/DataHandler.ashx',
        beforeLoadData: function (data) {
            for (var i in data.Data) {
                data.Data[i].NameID = ko.pureComputed(function () {
                    return this.Name + " " + this.MyID;
                }, data.Data[i]);
            }
        }
    });
});
