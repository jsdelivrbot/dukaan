$(function () {
    var browserWindow = $(window);
    var products_slider_detail = $('#products_slider_detail');
    var item_count = $('#products_slider_detail a').length;

    products_slider_detail.owlCarousel({
        margin: 5,
        dots: false,
        nav: item_count < 5 ? false : true,
        mouseDrag: item_count < 5 ? false : true,
        touchDrag: item_count < 5 ? false : true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: { items: 4, }
        }
    });

    $('#products_slider_detail a').click(function () {
        var src = $(this).find('img').attr('src');
        var zoom = $(this).find('img').attr('data-zoom-image');
        var detail = $(this).parent().parent().parent().parent().parent().find('.image-detail img');
        detail.attr('src', src);
        detail.attr('data-zoom-image', zoom);
        $('.zoomWindow').css('background-image', 'url("' + zoom + '")');
        return false;
    });

    if (browserWindow.width() >= 768) {
        $('.image-detail img').ezPlus({
            responsive: true,
            respond: [
                {
                    range: '1200-10000',
                    zoomWindowHeight: 490,
                    zoomWindowWidth: 782
                },
                {
                    range: '992-1200',
                    zoomWindowHeight: 400,
                    zoomWindowWidth: 649
                },
                {
                    range: '768-992',
                    zoomWindowHeight: 300,
                    zoomWindowWidth: 502
                },
                {
                    range: '100-768',
                    zoomWindowHeight: 0,
                    zoomWindowWidth: 0
                }
            ]
        });
    }

    $('.input-qty input').TouchSpin({
        verticalbuttons: true,
        prefix: 'qty'
    });

    $('.input-rating').raty({
        'half': true,
        'starType': 'i'
    });
});