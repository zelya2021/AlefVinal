var fileE = document.getElementById("inputID");
        fileE.onchange = function () {
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "/Home/Index");
            xhr.send(this.files[0]);
        }


        // скрипт, который обработает нажатие на кнопку и отправит данные на сервер


  // эта функция сработает при нажатии на кнопку

  function sendJSON(){

    // с помощью jQuery обращаемся к элементам на странице по их именам

    let value = document.querySelector('#inputValueSecond');

    let name = document.querySelector('#inputNameSecond');

    // а вот сюда мы поместим ответ от сервера

    let result = document.querySelector('.result');

    // создаём новый экземпляр запроса XHR

    let xhr = new XMLHttpRequest();

    // адрес, куда мы отправим нашу JSON-строку

    let url = "https://localhost:44383/Home/";

    // открываем соединение

    xhr.open("POST", url, true);

    // устанавливаем заголовок — выбираем тип контента, который отправится на сервер, в нашем случае мы явно пишем, что это JSON

    xhr.setRequestHeader("Content-Type", "application/json");

    // когда придёт ответ на наше обращение к серверу, мы его обработаем здесь

    xhr.onreadystatechange = function () {

      // если запрос принят и сервер ответил, что всё в порядке

      if (xhr.readyState === 4 && xhr.status === 200) {

            // выводим то, что ответил нам сервер — так мы убедимся, что данные он получил правильно

            result.innerHTML = this.responseText;

        }

    };

    // преобразуем наши данные JSON в строку

    var data = JSON.stringify({ "inputValueSecond": value.value, "inputNameSecond": name.value });

    // когда всё готово, отправляем JSON на сервер

    xhr.send(data);

}