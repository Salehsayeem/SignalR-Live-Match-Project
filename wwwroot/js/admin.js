var connection = new signalR.HubConnectionBuilder().withUrl("/matchcenterhub").build();
$(document).ready(function () {
    loadMatches();
    connection.start();

});

function loadMatches() {
    $.get("/api/Match", null, function (response) {
        bindMatches(response);
    });
}

function bindMatches(matches) {
    var html = "";
    $("#listMatches").html("");
    $.each(matches,
        function (index, match) {
            html += "<tr data-match-id='" + match.id + "'>";

            html += "<td>";
            html += "<img class='team-logo' width='15%' height='20%' src='/images/" + match.team1Logo + "'/>";
            html += "<span class='team-name'>" + match.team1Name + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team1Id + "' class='team-goals'>" + match.team1Goals +" "+ "</span>";
            html += "<input type='button' class='btn btn-success' value='Add Goal' data-match-id='" + match.id + "' data-team-id='" + match.team1Id + "' onclick='addGoal(this);' />";
            html += "</td>";

            html += "<td>";
            html += "<span class='team-separator'> — </span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team2Id + "' class='team-goals'>" + match.team2Goals + " " + "</span>";
            html += "<input type='button' class='btn btn-success' value='Add Goal' data-match-id='" + match.id + "' data-team-id='" + match.team2Id + "' onclick='addGoal(this);' />";

            html += "</td>";

            html += "<td>";
            html += "<img class='team-logo' width='15%' height='20%' src='/images/" + match.team2Logo + "'/>";
            html += "<span class='team-name'>" + match.team2Name + "</span>";
            html += "</td>";

            html += "</tr>";
        });
    $("#listMatches").append(html);
}

function addGoal(element) {
    var data =
    {
        matchId: $(element).attr("data-match-id"),
        teamId: $(element).attr("data-team-id")
    }

    $.ajax({
        type: 'PUT',
        url: 'api/Match',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done(function () {
        loadMatches();
        connection.invoke("SendMatchCentreUpdate").catch(function (err) {
            return console.error(err.toString());
        });
    });
}