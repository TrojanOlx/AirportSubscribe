function initCard(id, labels, series) {
    console.log(id);
    console.log(labels);
    console.log(series);

    var dataDailySalesChart = {
        labels: labels,
        series: series
    }

    console.log(dataDailySalesChart);

    var optionsDailySalesChart = {
        lineSmooth: Chartist.Interpolation.cardinal({
            tension: 0
        }),
        low: 0,
        high: 50, // creative tim: we recommend you to set the high sa the biggest value + something for a better look
        chartPadding: {
            top: 0,
            right: 0,
            bottom: 0,
            left: 0
        }
    }
    var chat = new Chartist.Line('#' + id, dataDailySalesChart, optionsDailySalesChart);


}