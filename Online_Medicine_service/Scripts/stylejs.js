var sliders = document.querySelectorAll('.slider');
var btns = document.querySelectorAll('.btn');
let currentslider = 1;


//javascript for image slider manual navigation

var manualnav = function (manual) {

    sliders.forEach((slide) => {
        slide.classList.remove('active');

        btns.forEach((btn) => {
            btn.classList.remove('active');
        });

    });

    sliders[manual].classList.add('active');
    btns[manual].classList.add('active');
}


btns.forEach((btn, i) => {

    btn.addEventListener("click", () => {
        manualnav(i);
        currentslider = i;
    });

});

//javaacript for image slider autoplay navigation

let repeat = function (activeclass) {
    let active = document.getElementsByClassName('active');
    let i = 1;

    var repeater = () => {
        setTimeout(function () {

            [...active].forEach((activeslider) => {
                activeslider.classList.remove('active');
            });

            sliders[i].classList.add('active');
            btns[i].classList.add('active');
            i++;


            if (sliders.length == i) {
                i = 0;
            }
            if (i >= sliders.length) {
                return;
            }
            repeater();
        }, 5000);

    }
    repeater();
}
repeat();
