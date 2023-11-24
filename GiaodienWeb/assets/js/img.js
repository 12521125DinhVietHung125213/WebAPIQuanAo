
const sliders = document.querySelectorAll('.slider');
const imgs = document.querySelectorAll('.slider-img');
const btnLeft = document.querySelector('.grid__slider-btn-left');
const btnRight = document.querySelector('.grid__slider-btn-right');
let counter = 0;

sliders.forEach(function(slider, index){
    slider.style.left = `${index * 100}%`;
})
btnLeft.addEventListener('click', function(){
    counter --;
    slick()
});
btnRight.addEventListener('click', function(){
    counter ++;
    slick()
})


function slick(){
    sliders.forEach(function(slider,index){
        slider.style.transform = `translateX(${-counter * 100}%)`;
    })
    if(counter == sliders.length - 1){
        btnRight.style.display = 'none';
    }
    else{
        btnRight.style.display = 'block';
    }
    if(counter >= 1){
        btnLeft.style.display = 'block'
    }
    else{
        btnLeft.style.display = 'none';
    }
    
}
btnLeft.style.display = 'none';
