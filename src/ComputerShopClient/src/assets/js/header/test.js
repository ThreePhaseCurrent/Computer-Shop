$( document ).ready(function() {
    $(window).scroll(function() {
      if(!$('nav').hasClass('fixed-color')) {
        $('nav').toggleClass('scrolled', $(this).scrollTop() > 650);
      }
    });
});
