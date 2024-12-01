Для настройки хранилища в appsettings.json использовать:

* `"Storage": "db",` для хранения в БД
* `"Storage": "file",` для хранения в ФС

Файлы БД и json файлы лежат в StoreManager.WEB/data.

Чтоб создать базу данных нужно ее промигрировать:
```shell
 dotnet ef database update --project StoreManager.DAL --startup-project StoreManager.WEB
```