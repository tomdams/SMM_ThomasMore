google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

function drawChart(data, options) {
    $.ajax(
        {
            type: 'POST',
            data: JSON.stringify(data),
            url: '/UIElement/getPolariteit',
            success:
            function (response) {
                var options =
                    {
                        width: 200,
                        height: 180,
                        sliceVisibilityThreshold: 0,
                        chartArea: { left: 30, top: 30, height: "90%" },
                        bar: { groupWidth: "50%" },
                        colors: ['#FF0000', '#00FF00'],
                        pieSliceText: 'label',
                        title: "Polariteit",
                        legend: 'none'
                    };

                var data = google.visualization.arrayToDataTable([
                    ['test', "test"],
                    ['Negatief', 50 - ((response / 2) * 100)],
                    ['Positief', 50 + ((response / 2) * 100)]
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