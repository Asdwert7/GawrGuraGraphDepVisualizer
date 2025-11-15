# 🦈 Визуализатор графа зависимостей (Акулья версия из Атлантиды)

## 🌊 Описание
Консольное приложение для визуализации графа зависимостей пакетов, вдохновленное акулой Гавргурой из Атлантиды. Программа анализирует конфигурационный файл YAML и выводит настроенные параметры с поддержкой фильтрации и обработки ошибок.

## ⚙️ Функциональность
- Чтение параметров из YAML-конфигурации
- Валидация всех настраиваемых параметров
- Обработка ошибок при некорректных значениях
- Фильтрация пакетов по подстроке
- Логирование параметров в формате ключ-значение

## 🚀 Запуск приложения

### Предварительные требования
- .NET 8.0 SDK
- YamlDotNet (автоматически устанавливается через NuGet)

### Установка зависимостей
```zsh
dotnet restore
```
### Запуск с указанием файла проекта
```zsh
dotnet run --project GawrGuraGraphDepVisualizer.csproj
```
# Примеры вывода:
```yaml
Configuration parameters:
PackageName: gavrgura-core
RepositoryPath: https://atlantis.packages.gov
RepositoryMode: Online
OutputImage: shark_graph.png
FilterSubstring: gawrgura
```
| Параметр | Тип | Описание |
|----------|-----|----------|
| `packageName` | string | Имя анализируемого пакета |
| `repositoryPath` | string | URL репозитория или путь к файлу |
| `repositoryMode` | enum | Режим работы (Online/Offline) |
| `outputImage` | string | Имя файла для изображения графа |
| `filterSubstring` | string | Подстрока для фильтрации пакетов |
|----------|-----|----------|

# 🐛 Проверка обработки ошибок
1. Отсутствующий файл конфигурации
```zsh
rm config.yaml
dotnet run --project GawrGuraGraphDepVisualizer.csproj
# Вывод: ERROR: Configuration file not found: config.yaml
```
2. Пустое имя пакета
```shell
# error_empty_package.yaml
packageName: ""
repositoryPath: "https://atlantis.packages.gov"
repositoryMode: Online
outputImage: "shark_graph.png"
filterSubstring: "gawrgura"

cp error_empty_package.yaml config.yaml
dotnet run --project GawrGuraGraphDepVisualizer.csproj
# Вывод: ERROR: PackageName cannot be empty
```
3. Некорректный режим репозитория
```zsh
# error_invalid_mode.yaml
packageName: "gavrgura-core"
repositoryPath: "https://atlantis.packages.gov"
repositoryMode: InvalidMode
outputImage: "shark_graph.png"
filterSubstring: "gawrgura"

cp error_invalid_mode.yaml config.yaml
dotnet run --project GawrGuraGraphDepVisualizer.csproj
# Вывод: ERROR: Invalid RepositoryMode value: InvalidMode
```
4. Синтаксическая ошибка YAML
```zsh
# syntax_error.yaml
packageName: [unclosed bracket
repositoryPath: "https://atlantis.packages.gov"

cp syntax_error.yaml config.yaml
dotnet run --project GawrGuraGraphDepVisualizer.csproj
# Вывод: ERROR: (Line: 2, Col: 3, Idx: 25) - (Line: 2, Col: 3, Idx: 25): While scanning a block scalar...
```
# 🧪 Тестирование
Для проверки корректной работы:

Убедитесь, что config.yaml содержит все обязательные параметры
Запустите приложение командой ```zsh dotnet run --project GawrGuraGraphDepVisualizer.csproj ```
Проверьте вывод параметров в формате ключ-значение
Протестируйте обработку ошибок с помощью примеров выше
# 🏺 История создания

Проект был создан в подводной лаборатории Атлантиды. 
Каждый байт кода был проверен акульими алгоритмами на соответствие требованиям морской безопасности.
Больше сделать не удалось, лаборатория затонула и я пошел спать))) 😪😴



