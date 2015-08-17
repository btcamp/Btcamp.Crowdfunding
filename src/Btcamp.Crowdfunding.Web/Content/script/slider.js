// JavaScript Document
(function ($) {

    $(document).ready(function () {
        var screen_width = 0;
        var screen_height = 0;
        function resize_slider() {
            screen_width = $(window).width();
            screen_height = $(window).height(); 
            $('#sec_small .item').css({
                height: 291,
                width: screen_width
            });
            $('#sec_small').css({
                height: 291,
                width:screen_width
        });
        };
        resize_slider();
        $(window).resize(resize_slider);

        //Slider Variables and Progress Bar
        var time = 7; // time in seconds
        var $progressBar,
			$bar,
			$elem,
			isPause,
			tick,
			percentTime;
        $(".full-slider").owlCarousel({
            slideSpeed: 500,
            paginationSpeed: 500,
            singleItem: true,
            pagination: false,
            afterInit: progressBar,
            afterMove: moved,
            startDragging: pauseOnDragging
        });
        //Init progressBar where elem is $("#owl-demo")
        function progressBar(elem) {
            $elem = elem;
            //build progress bar elements
            buildProgressBar();
            //start counting
            start();
        }
        //create div#progressBar and div#bar then prepend to $("#owl-demo")
        function buildProgressBar() {
            $progressBar = $("<div>", {
                id: "progressBar"
            });
            $bar = $("<div>", {
                id: "bar"
            });
            $progressBar.append($bar).prependTo($elem);
        }
        function start() {
            //reset timer
            percentTime = 0;
            isPause = false;
            //run interval every 0.01 second
            tick = setInterval(interval, 10);
        };
        function interval() {
            if (isPause === false) {
                percentTime += 1 / time;
                $bar.css({
                    width: percentTime + "%"
                });
                //if percentTime is equal or greater than 100
                if (percentTime >= 100) {
                    //slide to next item 
                    $elem.trigger('owl.next');
                }
            }
        }
        //pause while dragging 
        function pauseOnDragging() {
            isPause = true;
        }
        //moved callback
        function moved() {
            //clear interval
            clearTimeout(tick);
            //start again
            start();
        }
    });
}(jQuery));