
plugins = {
    isotope: $(".isotope")
};

var i, isogroup = [];
for (i = 0; i < plugins.isotope.length; i++) {
    var isotopeItem = plugins.isotope[i]
        , iso = new Isotope(isotopeItem, {
            itemSelector: '.isotope-item',
            layoutMode: isotopeItem.getAttribute('data-isotope-layout') ? isotopeItem.getAttribute('data-isotope-layout') : 'masonry',
            filter: '*'
        });

    isogroup.push(iso);
}

$(window).on('load', function () {
    setTimeout(function () {
        var i;
        for (i = 0; i < isogroup.length; i++) {
            isogroup[i].element.className += " isotope--loaded";
            isogroup[i].layout();
        }
    }, 600);
});

var resizeTimout;

$("[data-isotope-filter]").on("click", function (e) {
    e.preventDefault();
    var filter = $(this);
    clearTimeout(resizeTimout);
    filter.parents(".isotope-filters").find('.active').removeClass("active");
    filter.addClass("active");
    var iso = $('.isotope[data-isotope-group="' + this.getAttribute("data-isotope-group") + '"]');
    iso.isotope({
        itemSelector: '.isotope-item',
        layoutMode: iso.attr('data-isotope-layout') ? iso.attr('data-isotope-layout') : 'masonry',
        filter: this.getAttribute("data-isotope-filter") == '*' ? '*' : '[data-filter*="' + this.getAttribute("data-isotope-filter") + '"]'
    });
}).eq(0).trigger("click")
