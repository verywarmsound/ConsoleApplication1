﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerIcon.Model.AvitoModel
{
    public class AvitoAd
    {
        /// <summary>
        /// Обязательный 
        /// Уникальный идентификатор объявления в вашей базе данных — строка до 100 символов.
        ///У одного и того же объявления должен сохраняться один и тот же идентификатор от файла к файлу. Несоблюдение этого правила приведет к блокировке повторяющихся объявлений сайтом Avito.
        ///Для размещения нового объявления необходимо использовать новый идентификатор.
        ///пример
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Дата и время начала размещения объявления — можно задать одним из двух способов согласно стандарту ISO 8601:
        ///только дата в формате "YYYY-MM-DD" (MSK);
        ///или дата и время в формате "YYYY-MM-DDTHH:mm:ss+hh:mm".
        ///Важно: Объявление будет опубликовано в первый цикл автозагрузки, начавшийся в указанную дату и после указанного времени (если заданы дата и время). На практике это означает, что реальное время публикации может сильно зависеть от вашего расписания (режима) выгрузки и количества объявлений в файле.
        ///Если элемент не задан, объявление будет опубликовано сразу же после первого получения XML-файла с ним.
        ///<DateBegin>2015-12-24</DateBegin>
        ///<DateBegin>2017-04-06T21:58:00+03:00</DateBegin>
        /// </summary>
        public DateTime DateBegin { get; set; }

        /// <summary>	
        ///Дата, до которой включительно объявление актуально — в формате "YYYY-MM-DD" (MSK).
        ///Эта дата учитывается только во время циклов автозагрузки: если дата в прошлом, то новое объявление не будет опубликовано, а существующее — будет снято с публикации.
        ///Дата окончания размещения объявления на сайте Avito является стандартной (время до окончания можно увидеть в Личном кабинете). Если после этой даты объявление всё ещё присутствует в XML-файле и DateEnd не указан или указана текущая/будущая дата, то объявление будет снова активировано.
        ///<DateEnd>2079-08-28</DateEnd>
        /// </summary>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Вариант платного размещения — одно из значений списка
        ///«Package» — размещение объявления осуществляется только при наличии подходящего пакета размещения;
        ///«PackageSingle» — при наличии подходящего пакета оплата размещения объявления произойдет с него; если нет подходящего пакета, но достаточно денег на кошельке Avito, то произойдет разовое размещение;
        ///«Single» — только разовое размещение, произойдет при наличии достаточной суммы на кошельке Avito; если есть подходящий пакет размещения, он будет проигнорирован.
        ///Если элемент пуст или отсутствует, то значение по умолчанию — «Package».
        ///<ListingFee>PackageSingle</ListingFee>
        /// </summary>
        public string ListingFee { get; set; }

        /// <summary>	
        ///Платная услуга, которую нужно применить к объявлению — одно из значений списка:
        ///«Free» — обычное объявление;
        ///«Premium» — премиум-объявление;
        ///«VIP» — VIP-объявление;
        ///«PushUp» — поднятие объявления в поиске;
        ///«Highlight» — выделение объявления;
        ///«TurboSale»— применение пакета «Турбо-продажа»;
        ///«QuickSale» — применение пакета «Быстрая продажа».
        ///Если элемент пуст или отсутствует, то статус объявления по умолчанию — «Free».
        ///Для успешного применения платной услуги необходимо наличие денег на Кошельке Avito. Если денег на Кошельке недостаточно для применения услуги, объявление выгружается как обычное (Free).
        ///Одна платная услуга применяется к одному объявлению не чаще, чем один раз в определенный период времени:
        ///для услуг «Premium», «VIP», «Highlight» — раз в 7 дней, 
        ///для «PushUp» — раз в 2 дня, 
        ///пакеты услуг «QuickSale», «TurboSale» — раз в 7 дней. 
        ///Если по истечении указанного времени статус объявления в XML все еще отличается от «Free», то услуга будет применена повторно.
        ///Разные услуги для одного объявления активируются независимо друг от друга: одна услуга может быть активирована, пока еще не закончился срок действия другой. За один цикл автозагрузки можно применить только одну услугу.
        ///<AdStatus>QuickSale</AdStatus>
        /// </summary>
        public string AdStatus { get; set; }

        /*
            Номер объявления на Avito — целое число.
            Если вы разместили объявление вручную, а теперь хотите управлять объявлением с помощью Автозагрузки — укажите здесь номер объявления на сайте Авито.
            Элемент желательно использовать в процессе перехода с ручного размещения на Автозагрузку для того, чтобы:
            не создавать дубли объявлений, которые могут быть заблокированы;
            повторно не оплачивать платное размещение.
            Если есть сложности с добавлением отдельного элемента в XML, вы можете указать ссылку на номер объявления внутри элемента Description в следующем формате: «AvitoId: XXX» (где «XXX» — номер объявления). Эта информация на сайте показываться не будет.
            <!-- Вариант 1. Отдельный элемент -->
            <AvitoId>742817810</AvitoId> 
            <!-- Вариант 2. Внутри элемента Description -->
            <Description>Автомобиль покупался новым в мае 2013 года, все ТО пройдены по регламенту.
            AvitoId: 742817810
            </Description>
         */
        public string AvitoId { get; set; }

        /*
            Возможность написать сообщение по объявлению через сайт — одно из значений списка:
            «Да»,
            «Нет».
            Примечание: значение по умолчанию — «Да».
            <AllowEmail>Нет</AllowEmail>
         */
        public string AllowEmail { get; set; }

        /*
            Имя менеджера, контактного лица компании по данному объявлению — строка не более 40 символов.
            <ManagerName>Иван Петров-Водкин</ManagerName>
         */
        public string ManagerName { get; set; }

        /*
            Контактный телефон — строка, содержащая только один российский номер телефона; должен быть обязательно указан код города или мобильного оператора. Корректные примеры:
            «+7 (495) 777-10-66»,
            «(81374) 4-55-75»,
            «8 905 207 04 90»,
            «+7 905 2070490»,
            «88123855085»,
            «9052070490».
            <ContactPhone>+7 495 777-10-66</ContactPhone>
        */
        public string ContactPhone { get; set; }

        /*
            Регион, в котором находится объект объявления — в соответствии со значениями из справочника.
            http://autoload.avito.ru/format/Locations.xml
            <Region>Владимирская область</Region>
        */
        public string Region { get; set; }

        /* 
            Город или населенный пункт, в котором находится объект объявления — в соответствии со значениями из справочника.
            Элемент обязателен для всех регионов, кроме Москвы и Санкт-Петербурга.
            Справочник является неполным. Если требуемое значение в нем отсутствует, то укажите ближайший населенный пункт из справочника.
            <City>Муром</City>
            http://autoload.avito.ru/format/Locations.xml
         */
        public string City { get; set; }

        /*
            Ближайшая станция метро — в соответствии со значениями из справочника.
            <Subway>Белорусская</Subway>
            http://autoload.avito.ru/format/Locations.xml
         */
        public string Subway { get; set; }

        /*
            Район города — в соответствии со значениями из справочника.
            <District>Ленинский</District>
            http://autoload.avito.ru/format/Locations.xml
         */
        public string District { get; set; }

        /* 
            Элемент для добавления возможности запросить доставку. В элемент Delivery необходимо вложить параметры доставки, смотреть ниже.
            <Delivery>
                <WarehouseKey>34545</WarehouseKey>
                <Weight>3.2</Weight>
                <IsAllowPrepayment>Да</IsAllowPrepayment>
                <Width>10</Width>
                <Height>10</Height>
                <Length>20</Length>
            </Delivery>
         */
        public AvitoAdDelivery Delivery { get; set; }

        /* 
            Категория товара — одно из значений списка:
            Одежда, обувь, аксессуары
            Детская одежда и обувь
            Товары для детей и игрушки
            Часы и украшения
            Красота и здоровье
            <Category>Одежда, обувь, аксессуары</Category> 
         */
        public string Category { get; set; }

        /* 
            Вид товара — одно из значений списка (отдельно для каждой категории):
            Для категории «Одежда, обувь, аксессуары»:
            Женская одежда
            Мужская одежда
            Аксессуары
            Для категории «Детская одежда и обувь»:
            Для девочек
            Для мальчиков
            Для категории «Товары для детей и игрушки»:
            Автомобильные кресла
            Велосипеды и самокаты
            Детская мебель
            Детские коляски
            Игрушки
            Постельные принадлежности
            Товары для кормления
            Товары для купания
            Товары для школы
            Для категории «Часы и украшения»:
            Бижутерия
            Часы
            Ювелирные изделия
            Для категории «Красота и здоровье»:
            Косметика
            Парфюмерия
            Приборы и аксессуары
            Средства гигиены
            Средства для волос
            Средства для похудения
            <GoodsType>Женская одежда</GoodsType> 
         */
        public string GoodsType { get; set; }

        /* 
            Предмет одежды - одно из значений списка. Допустимые значения зависят от вида товара.
            Для вида товара «Женская одежда» (т.е. когда присутствует элемент <GoodsType>Женская одежда</GoodsType>):
            Брюки
            Верхняя одежда
            Джинсы
            Купальники
            Нижнее бельё
            Обувь
            Пиджаки и костюмы
            Платья и юбки
            Рубашки и блузки
            Свадебные платья
            Топы и футболки
            Трикотаж
            Другое
            Для вида товара «Мужская одежда» (т.е. когда присутствует элемент <GoodsType>Мужская одежда</GoodsType>):
            Брюки
            Верхняя одежда
            Джинсы
            Обувь
            Пиджаки и костюмы
            Рубашки
            Трикотаж и футболки
            Другое
            Для вида товара «Для девочек» (т.е. когда присутствует элемент <GoodsType>Для девочек</GoodsType>):
            Брюки
            Верхняя одежда
            Комбинезоны и боди
            Обувь
            Пижамы
            Платья и юбки
            Трикотаж
            Шапки, варежки, шарфы
            Другое
            Для вида товара «Для мальчиков» (т.е. когда присутствует элемент <GoodsType>Для мальчиков</GoodsType>):
            Брюки
            Верхняя одежда
            Комбинезоны и боди
            Обувь
            Пижамы
            Трикотаж
            Шапки, варежки, шарфы
            Другое
            <Apparel>Шапки, варежки, шарфы</Apparel> 
         */
        public string Apparel { get; set; }

        /* 
            Размер одежды или обуви — значение зависит от вида товара (GoodsType) и предмета одежды (Apparel).
            Для вида товара «Женская одежда»и «Мужская одежда»
            Для предметов одежды «Брюки», «Верхняя одежда», «Купальники», «Нижнее бельё», «Платья и юбки», «Рубашки и блузки», «Свадебные платья», «Топы и футболки», «Трикотаж»:

            число, соответствующее размеру одежды,
            или символьное обозначение, соответствующее международному: "S", "L" и т.д.
            или текст "Без размера".
            Для предметов одежды «Джинсы» и «Обувь»:

            число, соответствующее размеру одежды, обуви или текст "Без размера".
            Для вида товара «Для девочек» и «Для мальчиков»

            Для предметов одежды «Брюки», «Верхняя одежда», «Комбинезоны и боди», «Пижамы», «Платья и юбки», «Трикотаж»:
            число или диапазон чисел соответствующие размеру одежды в сантиметрах ,
            или соответствующие возрасту ребенка в годах/месяцах,
            или текст "Без размера".
            Для предметов одежды «Обувь»:
            число, соответствующее размеру одежды, обуви
            или текст "Без размера".
            <!-- Мужская и женская одежда -->
            <Size>42</Size>
            <Size>XXL</Size>
            <Size>Без размера</Size>
 
            <!-- Джинсы и обувь -->
            <Size>42</Size>
            <Size>Без размера</Size>
 
            <!-- Детская одежда -->
            <Size>42 см</Size>
            <Size>50-56 см</Size>
            <Size>6 мес</Size> 
            <Size>4 года</Size> 
            <Size>10-12 лет</Size>
 
            <!-- Детская обувь -->
            <Size>45</Size>
            <Size>Без размера</Size> 
         */
        public string Size { get; set; }

        /* 
            Название объявления — строка до 50 символов.
            Примечание: не пишите в название цену и контактную информацию — для этого есть отдельные поля — и не используйте слово «продам».
            <Title>Юбка пачка</Title> 
         */
        public string Title { get; set; }

        /* 
            Текстовое описание объявления в соответствии с правилами Avito — строка не более 3000 символов.
            Если у вас есть оплаченный Avito Магазин или Подписка, то поместив описание внутрь CDATA, вы можете использовать дополнительное форматирование с помощью HTML-тегов — строго из указанного списка: p, br, strong, em, ul, ol, li.

            <Description>Лёгкая и изящная юбка, не сковывает движения откроет ваши стройные гибкие ноги. На сцене такая юбка смотрится невероятно красиво и прелестно, она словно выступает неотъемлемым элементом происходящего там действия. Идеально подходит для вечера, корпоратива или же для повседневной жизни. Сделана из тонких полупрозрачных тканей – шифона, фатина, сетки и им подобных.
            </Description>


            <Description><![CDATA[
            <p>Лёгкая и изящная юбка, не сковывает движения откроет ваши стройные гибкие ноги. На сцене такая юбка смотрится невероятно красиво и прелестно, она словно выступает неотъемлемым элементом происходящего там действия. Идеально подходит для вечера, корпоратива или же для повседневной жизни.</p>
            <p>Сделана из тонких полупрозрачных тканей:</p>
            <ul>
            <li>шифона</li>
            <li>фатина</li>
            <li>сетки</li>
            </ul>
            ]]></Description>
            Price	
            Цена в рублях — целое число. 

            <Price>25000</Price> 
         */
        public string Description { get; set; }

        /* 
            Цена в рублях — целое число. 
            <Price>25000</Price>
         */
        public int Price { get; set; }

        /*
            Фотографии — вложенные элементы, по одному элементу «Image» на каждое изображение. На файл фотографии можно ссылаться одним из следующих способов (указание обоих атрибутов не допускается):
            в виде HTTP-ссылки — атрибут «url»;
            при передаче вместе с XML-файлом (во время загрузки через Личный кабинет или по электронной почте) — атрибут «name».
            Допустимые графические форматы фотографий: JPEG, PNG.

            Для каждой категории определено максимальное количество фотографий, которые можно прикрепить к объявлению (все фотографии свыше этого количества игнорируются):

            Максимальное количество фотографий для раздела «Личные вещи» — 10 фото.
            <Images>
	            <Image url="http://img.test.ru/8F7B-4A4F3A0F2BA1.jpg" />
	            <Image url="http://img.test.ru/8F7B-4A4F3A0F2XA3.jpg" />
            </Images>
 
 
            <Images>
	            <Image name="a1.jpg"/>
	            <Image name="a2.jpg"/>
	            <Image name="a3.jpg"/>
            </Images> 
         */
        public List<string> Images { get; set; }

        /* 
            Пример XML файла
            <AvitoAds formatVersion="3" target="Avito.ru">
                <AvitoAd>
                    <Id>723681273</Id>
                    <DateBegin>2015-11-27</DateBegin>
                    <DateEnd>2079-08-28</DateEnd>
                    <AdStatus>TurboSale</AdStatus>
                    <AllowEmail>Да</AllowEmail>
                    <ManagerName>Иван Петров-Водкин</ManagerName>
                    <ContactPhone>+7 916 683-78-22</ContactPhone>
                    <Region>Владимирская область</Region>
                    <City>Владимир</City>
                    <District>Ленинский</District>
                    <Category>Одежда, обувь, аксессуары</Category>
                    <GoodsType>Женская одежда</GoodsType>
                    <Apparel>Платья и юбки</Apparel>
                    <Size>S</Size>
                    <Title>Прекрасное платье</Title>
                    <Description><![CDATA[
            <p>Лёгкая и изящная юбка, не сковывает движения откроет ваши стройные гибкие ноги. На сцене такая юбка смотрится невероятно красиво и прелестно, она словно выступает неотъемлемым элементом происходящего там действия. Идеально подходит для вечера, корпоратива или же для повседневной жизни.</p>
            <p>Сделана из тонких полупрозрачных тканей:</p>
            <ul>
            <li>шифона</li>
            <li>фатина</li>
            <li>сетки</li>
            </ul>
            ]]></Description>
                    <Price>25300</Price>
                    <Images>
                        <Image url="http://img.test.ru/8F7B-4A4F3A0F2BA1.jpg" />
                        <Image url="http://img.test.ru/8F7B-4A4F3A0F2XA3.jpg" />
                    </Images>
                </AvitoAd>
            </AvitoAds>
         */

        public AvitoAd()
        {
            Images = new List<string>();
        }
    }
}