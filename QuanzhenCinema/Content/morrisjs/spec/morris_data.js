$(function () {

    Morris.Area({
        element: 'morris-area-chart',
        data: [
{ time: '2016-07-15', NeverGone: 230340, ColdWar: 307050 },
{ time: '2016-07-16', NeverGone: 202220, ColdWar: 254070 },
{ time: '2016-07-17', NeverGone: 199760, ColdWar: 166710 },
{ time: '2016-07-18', NeverGone: 252150, ColdWar: 124550 },
{ time: '2016-07-19', NeverGone: 320350, ColdWar: 92060 },
{ time: '2016-07-20', NeverGone: 359800, ColdWar: 91306 },
{ time: '2016-07-21', NeverGone: 400050, ColdWar: 100390 }
        ],
        xkey: 'time',
        ykeys: ['NeverGone', 'ColdWar'],
        labels: ['NeverGone', 'Total'],
        pointSize: 2,
        hideHover: 'auto',
        resize: true
    });

    Morris.Donut({
        element: 'morris-donut-chart',
        //data: [{
        //    label: "Download Sales",
        //    value: 12
        //}, {
        //    label: "In-Store Sales",
        //    value: 30
        //}, {
        //    label: "Mail-Order Sales",
        //    value: 20
        //}],
        data: [
    {
        label: "豆瓣",
        value: 0.86
    },
    {
        label: "柜台",
        value: 0.14
    }
        ],
        resize: true
    });

    Morris.Bar({
        element: 'morris-bar-chart',
        data: [{
            y: '2006',
            a: 100,
            b: 90
        }, {
            y: '2007',
            a: 75,
            b: 65
        }, {
            y: '2008',
            a: 50,
            b: 40
        }, {
            y: '2009',
            a: 75,
            b: 65
        }, {
            y: '2010',
            a: 50,
            b: 40
        }, {
            y: '2011',
            a: 75,
            b: 65
        }, {
            y: '2012',
            a: 100,
            b: 90
        }],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['Series A', 'Series B'],
        hideHover: 'auto',
        resize: true
    });

});