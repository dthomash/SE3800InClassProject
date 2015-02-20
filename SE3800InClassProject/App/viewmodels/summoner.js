define(['plugins/http'], function (http) {
    var ctor = function () {
        this.displayName = 'LolSmurf Search';
        this.description = 'Durandal is a cross-device, cross-platform client framework written in JavaScript and designed to make Single Page Applications (SPAs) easy to create and maintain.';
        this.summonerName = "";
        this.summonerLevel = "";

        var that = this;

        this.activate = function (params) {
            var summonerName = { summonerName : params.summonerName };
            return http.get("api/summoner", summonerName).then(function (response) {
                that.summonerName = response.SummonerName;
                that.summonerIconId = response.SummonerIconId;
                that.summonerLevel = response.summonerLevel;
            },function(response) {
                alert("Search failed");
            });
        };
    };

    return ctor;
});