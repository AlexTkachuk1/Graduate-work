var CreateSliderModule = (function createSliderModule() {

    var arrayImgSrc = [];
    var currentIndex = 0;
    var mainBlock;
    function previous() {
        currentIndex--;
        updateImage();
    }
    function next() {
        currentIndex++;
        updateImage();
    }
    function updateImage() {
        if (currentIndex < 0) {
            currentIndex += arrayImgSrc.length;
        }
        if (currentIndex >= arrayImgSrc.length) {
            currentIndex -= arrayImgSrc.length;
        }
        var url = arrayImgSrc[currentIndex];
        var string = url.url;

        $('.visible-image').attr('src', string)
        $('.current').text(currentIndex + 1)
        $('.maxCount').text(arrayImgSrc.length)
    }
    function createButton(className, value) {
        var buttonBlock = $('<div>');
        buttonBlock.addClass('paginator-button')

        var button = $("<button class='" + className + "'>" + value + "</>");
        buttonBlock.append(button);
        return buttonBlock;
    }
    function createHtml() {
        var sliderBlock = $('<div>');
        sliderBlock.addClass('my-slider');

        var previousButton = createButton('previous', 'Previous');
        sliderBlock.append(previousButton);

        var imageBlock = $('<div>');
        imageBlock.addClass('image-block')
        var spanCounter = $("<span class='counter'><span class='current'></span>/<span class='maxCount'></span></span>")
        imageBlock.append(spanCounter);
        var img = $("<img class ='visible-image' />");
        imageBlock.append(img);
        sliderBlock.append(imageBlock);

        var nextButton = createButton('next', 'Next');
        sliderBlock.append(nextButton);

        mainBlock.append(sliderBlock);
    }
    function init(urls) {
        $('.next').click(next);
        $('.previous').click(previous);
        arrayImgSrc = urls;
        updateImage();
    }
    return {
        Start: init
    };

})();