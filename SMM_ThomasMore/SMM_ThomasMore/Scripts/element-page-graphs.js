 google.charts.load('current', {'packages':['corechart']});
 google.charts.setOnLoadCallback(drawChart);

function drawChart(data,options) {
    $.ajax(
        {
            type: 'POST',
            data: JSON.stringify(data),
            url: '/UIElement/getPolariteit',
            success:
            function (response) {
                var options =
                    {
                        width: 1100,
                        height: 900,
                        sliceVisibilityThreshold: 0,
                        legend: { position: "top", alignment: "end" },
                        chartArea: { left: 370, top: 50, height: "90%" },
                        bar: { groupWidth: "50%" },
                        colors: ['#00FF00','#FF0000']
                    };

                var data = google.visualization.arrayToDataTable([
                    ['test', "test"],
                    ['Positief', 50 + ((response / 2)*100)],
                    ['Negatief', 50 - ((response / 2)*100)]
                ]);

                var chart = new google.visualization.PieChart(document.getElementById('piechart'));
                chart.draw(data, options);

            },
            error: function (ex) {
                console.log(ex);
                console.log(ex.responseText);
                console.log('memes');
            }
        });
   
}