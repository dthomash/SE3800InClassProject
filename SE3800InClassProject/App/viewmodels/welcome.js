define(function() {
    var ctor = function () {
        this.displayName = 'LolSmurf Search';
        this.description = 'Durandal is a cross-device, cross-platform client framework written in JavaScript and designed to make Single Page Applications (SPAs) easy to create and maintain.';
        this.search = function() {
            var searchTerm = $('#searchBox').val();
            window.location.href += '#summoner?summonerName=' + searchTerm;
        }
    };

    return ctor;
});