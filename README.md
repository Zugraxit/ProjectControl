# ProjectControl
ProjectControl - простая система управления задачами, позволяющая небольшим командам организовывать работу, отслеживать статус задач и фиксировать прогресс.

## Инструкции по установке
На серверной части создайте и настройте БД, используя файл project_control_db.sql, после чего измените строку подключения к БД в файле конфигурации установленного API. После всех процедур запустите API.
На клиентской части измените константы для подключения к API (lib/common/constants/app_urls.dart). После всех процедур запустите клиентское приложение.

## Используемые технологии
* Серверная часть: C#, ASP.Net Core 
* Клиентская часть: Dart, Flutter
* БД: MySQL

## Руководство пользователя
При запуске приложения вас встречает окно авторизации.
![Окно авторизации](https://sun9-44.userapi.com/impg/xT4LE7v57Aj7Gzr2vrpYdJ6Fa9njrIy_aV88fA/gKzD5ne5XPw.jpg?size=1378x661&quality=95&sign=818c67721877e2d642c4b6eb520f1cdb&type=album)
Для регистрации нового пользователя необходимо нажать на кнопку "Зарегистрироваться", на открывшейся странице заполнить поля Логин, Никнейм, Пароль и Подтверждение пароля соответствующими данными (например, CommonUser, Иван, qwerty123, qwerty123), после чего нажать на кнопку "Зарегистрироваться". После регистрации вас вернёт на страницу авторизации.
![Окно авторизации - Регистрация](https://sun9-15.userapi.com/impg/_KRuZ5jc0CE91bwaWAgjCx3ETpoUmngIuajKUg/G86vwmNcuHE.jpg?size=1373x649&quality=95&sign=dcbb64ebf7e90c54a5029ecd04033289&type=album)
![Окно регистрации](https://sun9-27.userapi.com/impg/FPaCt6wPGoTbzq0Ucc5XGwBliX5YT-pDnH2xDg/OWa4Gh5k_VY.jpg?size=1372x710&quality=95&sign=d6ac2f03945bf6765662b5dfb9f8f0cb&type=album)
![Окно регистрации - Заполнено](https://sun9-57.userapi.com/impg/O63bz4pISfzW5OQyvqn261Cgw4poXQ0nhzz-Ww/z1-x01Mq774.jpg?size=1366x690&quality=95&sign=898867ac18a0849d40314fe3afaa92fb&type=album)
![Окно авторизации - После регистрации](https://sun9-46.userapi.com/impg/UkBBwmmASKaUveFoDPdBSLI1flEbifyUfwV-iQ/TvAkTH3woS0.jpg?size=1368x696&quality=95&sign=daa4b8f2360ef86d3b9dbd8c463447f4&type=album)
Для авторизации небоходимо на странице авторизации заполнить поля Логин и Пароль (например, CommonUser и qwerty123), после чего нажать на кнопку "Войти". После авторизации вас перенаправит на главную страницу.
![Окно авторизации - Заполнено](https://sun9-6.userapi.com/impg/Zf7aa08aTXJxzf1n8qW12cOfdeTDxp5SW2xfkA/L_FNM_6UuuU.jpg?size=1346x567&quality=95&sign=a25d48c8f5f8025271ff58d085de2826&type=album)

## Команда проекта
* Богданов Максим - лучший UseCase-дизайнер, опытный DungeonMaster, разработчик БД, редактор прекрасного README
* Стрельцов Владислав - опытный Flutter-разработчик, разработчик Front-End
* Чурсанов Олег - опытный 1С-разработчик, лучший Figma-дизайнер, разработчик API

![GigaTeam](https://sun9-74.userapi.com/impg/qamsxCFdpxqSiuP_n8jkV2ilRn5GglKpQRnZjQ/tuNJ-yMy0Z8.jpg?size=736x736&quality=95&sign=6b888d97f2d419cd9413871ef0c18ae9&type=album)
