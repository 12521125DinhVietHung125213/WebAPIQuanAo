const modal = document.querySelector('.modal-img-product');
const imgMain = document.querySelectorAll('.img-product-item-list')
const closeslider = document.querySelector('.close-slider')

closeslider.addEventListener('click', closemodal)
for(var x of imgMain){
    x.addEventListener('click' , showmodal)
}
function showmodal(){
    modal.style.display = 'block'
}
function closemodal(){
    modal.style.display = 'none'

}
var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
  showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("myslider");
    var dots = document.getElementsByClassName("modalslider-content-img");
    if (n > slides.length) {
        slideIndex = 1
    }
    if (n < 1) {
        slideIndex = slides.length
    }
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex-1].style.display = "block";
    dots[slideIndex-1].className += " active";
    
}
var fullScreen = document.querySelector('.fullscreen')
var fullimg = document.querySelectorAll('.img-product-item-list')
for ( var x of fullimg){
    fullScreen.onclick = function(e){
        if (x.requestFullscreen) {
            x.requestFullscreen();
        } else if (x.webkitRequestFullscreen) { /* Safari */
            x.webkitRequestFullscreen();
        } else if (x.msRequestFullscreen) { /* IE11 */
            x.msRequestFullscreen();
        }
    }
}

document.addEventListener('keydown', function(e){
    if(e.keyCode == 27){
        modal.style.display = 'none'
    }
})

