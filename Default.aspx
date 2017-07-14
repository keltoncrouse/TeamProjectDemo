<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeamProjectWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="lblMessage" runat="server" />

    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/AngularBinder.js"></script>
    <script src="Scripts/Controller.js"></script>
    <link href="Content/Tables.css" rel="stylesheet" />


    <div ng-app="Binder">
        <h2>Season scores</h2>
        <p>Here you can see the current score for all players in the league. <br /> <br /></p>
        <%--<asp:Label ID="jsonlabel" runat="server" />--%>

        <div ng-controller="Roster">
            
            <div class="searchfunction"><p><strong>Type in any Player, Team or Score here to filter results</strong></p>
            <form class="form-inline">
                <input ng-model="searchquery" type="text"
                    placeholder="Filter by" autofocus>
            </form>
            
            </div>
                <table>
            
                <tr>
                    <th>Player</th>
                    <th>Team</th>
                    <th>Season Score</th>
                </tr>
                <tr ng-repeat="player in leagueroster | filter:searchquery">
                    <td>{{player.PlayerName}}</td>
                    <td>{{player.TeamName}}</td>
                    <td style="text-align: center">{{player.TotalScores}}</td>
                </tr>
            </table>
        </div>
    </div>



</asp:Content>
