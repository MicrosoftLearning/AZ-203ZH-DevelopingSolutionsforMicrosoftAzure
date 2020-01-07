---
lab:
    title: '实验：构造多语言数据解决方案'
    type: '答案'
    module: '模块 3：开发 Azure 存储'
---

# 实验：构造多语言数据解决方案
# 学生实验答案

## Microsoft Azure 用户界面

鉴于 Microsoft 云工具的动态特性，Azure 用户界面 (UI) 在此培训内容开发之后可能会发生更改。这些更改可能会导致实验说明和步骤不相符。

一旦 Microsoft 通过社区注意到必要更改，将会立即更新此培训课程。但由于云更新频繁，你可能会在此培训内容更新前遇到 UI 更改。**如果发生这种情况，请适应这些更改并根据需要在实验中熟悉这些更改。**

## 说明

### 开始前

#### 登录实验虚拟机

使用以下凭据登录 **Windows 10** 虚拟机：
    
-   **用户名**： Admin

-   **密码**： Pa55w.rd

> **注意**： 讲师将为你提供实验虚拟机登录说明。

#### 查看已安装的应用程序

查看位于 **Windows 10** 桌面底部的任务栏。任务栏包含你将在本实验中使用的应用程序的图标：
    
-   Microsoft Edge

-   文件资源管理器

-   Visual Studio Code

#### 下载实验文件

1.  在任务栏上，选择 **Windows PowerShell** 图标。

1.  在 PowerShell 命令提示符中，将当前工作目录更改为 **Allfiles (F):\\** 路径：

```
cd F:
```

1.  在命令提示符中，输入以下命令并按 Enter，以将 GitHub 上托管的 **microsoftlearning/AZ-203-DevelopingSolutionsforMicrosoftAzure** 项目克隆到 **Allfiles (F):\\** 驱动器：

```
git clone --depth 1 --no-checkout https://github.com/microsoftlearning/AZ-203-DevelopingSolutionsForMicrosoftAzure .
```

1.  在命令提示符中，输入以下命令并按 **Enter**，以签出完成 **AZ-203T03** 实验所需的实验文件：

```
git checkout master -- Allfiles/*
```

1.  关闭当前正在运行的 **Windows PowerShell** 命令提示应用程序。

### 练习 1：在 Azure 中创建数据库资源

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

1.  在打开的浏览器窗口中，导航到 **Azure 门户** ([portal.azure.com](https://portal.azure.com))。

1.  输入 Microsoft 帐户的 **电子邮件地址**。

1.  选择 **下一步**。

1.  输入 Microsoft 帐户的 **密码**。

1.  选择 **登录**。

    > **注意**： 如果这是你第一次登录 **Azure 门户**，系统会出现一个提供门户导览的对话框。选择 **开始使用**，以跳过导览，开始使用门户。

#### 任务 2：创建 Azure Cache for Redis 资源

1.  在 Azure 门户左侧的导航窗格中，选择 **所有服务**。

1.  在 **所有服务** 边栏选项卡中，选择 **Azure Cache for Redis**。

1.  在 **Azure Cache for Redis** 边栏选项卡中，查看你的 Redis 缓存实例列表。

1.  在 **Azure Cache for Redis** 边栏选项卡顶部，选择 **+ 添加。

1.  在 **新建 Redis 缓存** 边栏选项卡中，执行以下操作：

    1.  在 **DNS 名称** 字段中，输入值 **polyrediscache\[你的名称的小写形式\]** 

    1.  将 **订阅** 下拉列表设置为默认值。
    
    1.  在 **资源组** 部分，选择 **新建**，输入 **PolyglotData**，然后选择 **确定**。
    
    1.  在 **位置** 下拉列表中，选择 **美国东部** 选项。

    1.  在 **定价层** 列表中，选择 **基本 C0（250MB 缓存）** 选项。

    1.  在 **取消阻止端口 6379（非 SSL 加密）** 部分，请确保未选中复选框。
    
    1. 选择 **创建**。

1.  等待创建任务完成，再继续本实验。

    > **注意**：可能需要等待 **15 - 30 分钟** 才能开始使用 Azure Cache for Redis 资源。你可以选择继续执行实验，但必须记住，**练习 6： 编写 .NET 代码以连接到 Azure Redis 缓存”需要此资源及其连接字符串**。

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polyrediscache\** Azure Cache for Redis 实例。

1.  在 **Azure Cache for Redis** 边栏选项卡中，找到边栏选项卡左侧的 **设置** 部分，并选择 **访问密钥** 链接。

1.  在 **访问密钥** 窗格中，将值记录在 **主连接字符串 (StackExchange.Redis)** 字段中。稍后你将在本实验中使用此值。

#### 任务 3：创建 Azure SQL 服务器资源

1.  在 Azure 门户左侧的导航窗格中，选择 **所有服务**。

1.  在 **所有服务** 边栏选项卡中，选择 **SQL 服务器**。

1.  在 **SQL 服务器** 边栏选项卡中，查看 SQL 服务器实例列表。

1.  在 **SQL 服务器** 边栏选项卡顶部，选择 **+ 添加**。

1.  在 **创建 SQL Database 服务器** 边栏选项卡中，查看边栏选项卡顶部的选项卡，如 **基本**、**网络** 和 **其他设置**。

    > **注意**：每个选项卡都代表在创建新的 **Azure SQL Database 服务器** 的工作流中的一个步骤。可以随时选择 **查看 + 创建** 跳过剩余选项卡。

1.  在 **基本** 选项卡中，执行以下操作：
    
    1.  将 **订阅** 下拉列表设置为默认值。
    
    1.  在 **资源组** 部分中，从列表中选择 **PolyglotData**。
    
    1.  在 **服务器名称** 字段中，输入值 **polysqlsrvr\[你的名称的小写形式\]**。
    
    1.  在 **位置** 下拉列表中，选择 **(US) 美国东部** 选项。
    
    1.  在 **服务器管理员登录名** 字段中，输入值 **testuser**。
    
    1.  在 **密码** 字段中，输入值 **TestPa$$w0rd**。
    
    1.  在 **确认密码** 字段中，再次输入值 **TestPa$$w0rd**。

    1.  选择 **下一步：网络 >**。

1.  在 **网络** 选项卡中，执行以下操作：

    1. 在 **允许 Azure 服务和资源访问此服务器** 部分，选择 **是**。
    
    1.  选择 **查看 + 创建**。

1.  在 **查看 + 创建** 选项卡中，查看在上述步骤中选择的选项。

1.  选择 **创建** 以使用指定的配置创建 Azure SQL Database 服务器。

1.  等待创建任务完成，再继续本实验。

#### 任务 4：创建 Azure Cosmos DB 帐户资源

1.  在 Azure 门户左侧的导航窗格中，选择 **所有服务**。

1.  在 **所有服务** 边栏选项卡中，选择 **Azure Cosmos DB**。

1.  在 **Azure Cosmos DB** 边栏选项卡中，查看 Azure Cosmos DB 实例的列表。

1.  在 **Azure Cosmos DB** 边栏选项卡顶部，选择 **+ 添加**。

1.  在 **创建 Azure Cosmos DB 帐户** 边栏选项卡中，查看边栏选项卡顶部的选项卡，如 **基本**、 **网络** 和 **标记**。

    > **注意**： 每个选项卡都代表在创建新的 **Azure Cosmos DB 帐户** 的工作流中的一个步骤。可以随时选择 **查看 + 创建** 跳过剩余选项卡。

1.  在 **基本** 选项卡中，执行以下操作：
    
    1.  将 **订阅** 列表设置为其默认值。
    
    1.  在 **资源组** 部分中，从列表中选择 **PolyglotData**。
    
    1.  在 **AccountName** 字段中，输入 **polycosmos\[你的名称的小写形式\]**。
    
    1.  在 **API** 下拉列表中，选择 **核心 (SQL)** 选项。
    
    1.  在 **位置** 下拉列表中，选择 **美国东部** 区域。
    
    1.  在 **异地冗余** 部分，选择 **禁用** 选项。
    
    1.  在 **多区域写入** 部分，选择 **禁用** 选项。
    
    1.  选择 **查看 + 创建**。

1.  在 **查看 + 创建** 选项卡中，查看在上述步骤中选择的选项。

1.  选择 **创建**，使用指定的配置创建 Azure Cosmos DB 帐户。

1.  等待创建任务完成，再继续本实验。

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polycosmos\** Azure Cosmos DB 帐户。

1.  在 **Azure Cosmos DB 帐户** 边栏选项卡中，找到边栏选项卡左侧的 **设置** 部分，选择 **密钥** 链接。

1.  在 **密钥** 窗格中，将值记录在 **主连接字符串** 字段中。稍后你将在本实验中使用此值。

#### 任务 5：创建 Azure 存储帐户资源

1.  在 Azure 门户左侧的导航窗格中，选择 **所有服务**。

1.  在 **所有服务** 边栏选项卡中，选择 **存储帐户**。

1.  在 **存储帐户** 边栏选项卡中，查看存储实例列表。

1.  在 **存储帐户** 边栏选项卡顶部，选择 **+ 添加**。

1.  在 **创建存储帐户** 边栏选项卡中，查看边栏选项卡顶部的选项卡，如 **基本**、**高级** 和 **标记**。

    > **注意**： 每个选项卡都代表在创建新 **Azure 存储帐户** 的工作流中的一个步骤。可以随时选择 **查看 + 创建** 跳过剩余选项卡。

1.  在 **基本** 选项卡中，执行以下操作：
    
    1.  将 **订阅** 列表设置为其默认值。
    
    1.  在 **资源组** 部分中，从列表中选择 **PolyglotData**。
    
    1.  在 **存储帐户名称** 字段中，输入 **polystor\[你的名称的小写形式\]**。
    
    1.  在 **位置** 下拉列表中，选择 **美国东部** 区域。
    
    1.  在 **性能** 部分中，选择 **标准**。
    
    1.  在 **帐户种类** 下拉列表中，选择 **StorageV2（常规用途 v2）**。
    
    1.  在 **复制** 下拉列表中，选择 **本地冗余存储 (LRS)**。
    
    1.  在 **访问层（默认）** 部分，请确保已选中 **热**。
    
    1.  选择 **查看 + 创建**。

1.  在 **查看 + 创建** 选项卡中，查看在上述步骤中选择的选项。

1.  选择 **创建**，使用指定的配置创建存储帐户。

1.  等待创建任务完成，再继续本实验。

#### 回顾

在本练习中，你创建了多语言数据解决方案所需的所有 Azure 资源。

### 练习 2：导入数据库和映像

#### 任务 1：上传映像 blob

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polystor\** 存储帐户。

1.  在 **存储帐户** 边栏选项卡中，选择位于边栏选项卡左侧 **Blob 服务** 部分的 **容器** 链接。

1.  在 **容器** 部分，选择 **+ 容器**。

1.  在 **新建容器** 弹出窗口中，执行以下操作：
    
    1.  在 **名称** 字段中，输入 **images**。
    
    1.  在 **公共访问级别** 下拉列表中，选择 **Blob（仅限 blob 匿名读取访问权限）**。
    
    1.  选择 **确定**。

1.  返回 **容器** 部分，选择新创建的 **images** 容器。

1.  在 **容器** 边栏选项卡中，找到边栏选项卡左侧的 **设置** 部分，选择 **属性** 链接。

1.  在 **属性** 窗格中，将值记录在 **URL** 字段中。稍后你将在本实验中使用此值。

1.  找到并选择边栏选项卡左侧的 **概览** 链接。

1.  在边栏选项卡顶部，选择 **上传**。

1.  在 **上传 blob** 弹出窗口中，执行以下操作：
    
    1.  在 **文件** 部分，选择 **文件夹** 图标。
    
    1.  在 **文件资源管理器** 对话框中，转到 **Allfiles (F):\\Allfiles\\Labs\\03\\Starter\\Images**，选择全部四十二个 jpg 图像文件，然后选择 **打开**。
    
    1.  确保 **如果文件已存在，请覆盖** 已选中。
    
    1.  选择 **上传**。

1. 等待所有 blob 上传完成，然后再继续本实验。

#### 任务 2：上传 SQL .bacpac 文件

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polystor\** 存储帐户。

1.  在 **存储帐户** 边栏选项卡中，选择位于边栏选项卡左侧 **Blob 服务** 部分的 **容器** 链接。

1.  在 **容器** 部分，选择 **+ 容器**。

1.  在 **新建容器** 弹出窗口中，执行以下操作：
    
    1.  在 **名称** 字段中，输入 **databases**。
    
    1.  在 **公共访问级别** 下拉列表中，选择 **专用（非匿名访问）**。
    
    1.  选择 **确定**。

1.  返回 **容器** 部分，选择新创建的 **databases** 容器。

1.  在 **容器** 边栏选项卡中，选择 **上传**。

1.  在 **上传 blob** 弹出窗口中，执行以下操作：
    
    1.  在 **文件** 部分，选择 **文件夹** 图标。
    
    1.  在 **文件资源管理器** 对话框中，转到 **Allfiles (F):\\Allfiles\\Labs\\03\\Starter**，选择 **AdventureWorks.bacpac** 文件，然后选择 **打开**。
    
    1.  确保 **如果文件已存在，请覆盖** 已选中。
    
    1.  选择 **上传**。

1. 等待 blob 上传完成，然后再继续本实验。

#### 任务 3：导入 SQL 数据库

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polysqlsrvr\** SQL 服务器。

1.  在 **SQL 服务器** 边栏选项卡中，选择 **导入数据**。

1.  在出现的 **导入数据库** 边栏选项卡中，执行以下操作：

    1.  将 **订阅** 列表设置为其默认值。

    1.  选择 **存储** 选项。

    1.  在出现的 **存储帐户** 边栏选项卡中，选择你之前在本实验中创建的 **polystor\** 存储帐户。 

    1.  在 **容器** 边栏选项卡中，选择你之前在本实验中创建的 **databases** 容器。 

    1.  在出现的 **容器** 边栏选项卡中，选择你之前在本实验中创建的 **AdventureWorks.bacpac** blob，然后选择 **选择** 关闭边栏选项卡。

    1.  返回 **导入数据库** 边栏选项卡，将 **定价层** 选项设置为其默认值。

    1.  在 **数据库名称** 字段中，输入 **AdventureWorks**。

    1.  将 **排序规则** 字段设置为其默认值。

    1.  在 **服务器管理员登录名** 字段中，输入值 **testuser**。
    
    1.  在 **密码** 字段中，输入值 **TestPa$$w0rd**。
    
    1.  选择 **确定**。

1. 等待数据库创建完成，然后再继续本实验。

#### 任务 4：使用导入的 SQL 数据库

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polysqlsrvr\** SQL 服务器。

1.  在 **SQL 服务器** 边栏选项卡中，找到边栏选项卡左侧的 **安全性** 部分，选择 **防火墙和虚拟网络** 链接。

1.  在 **防火墙和虚拟网络** 窗格中，选择 **添加客户端 IP**，然后选择 **保存**。

    > **注意**： 此步骤将确保本地计算机是否可以访问与此服务器关联的数据库。

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **AdventureWorks** SQL 数据库。

1.  在 **SQL 数据库** 边栏选项卡中，找到边栏选项卡左侧的 **设置** 部分，选择 **连接字符串** 链接。

1.  在 **连接字符串** 窗格中，将值记录在 **ADO.NET（SQL 身份验证）** 字段中。稍后你将在本实验中使用此值。

1.  通过执行以下操作更新记录的连接字符串：

    1.  在连接字符串中，找到 ``{your_username}``占位符，并将其替换为 ``testuser``。

    1.  在连接字符串中，找到 ``{your_password}`` 占位符，并将其替换为 ``TestPa$$w0rd``。

        > **注意**： 例如，如果连接字符串最初是 ``Server=tcp:polysqlsrvrinstructor.database.windows.net,1433;Initial Catalog=AdventureWorks;User ID={your_username};Password={your_password};``，更新后的连接字符串将是 ``Server=tcp:polysqlsrvrinstructor.database.windows.net,1433;Initial Catalog=AdventureWorks;User ID=testuser;Password=TestPa$$w0rd;``

1.  找到并选择边栏选项卡左侧的 **查询编辑器** 链接。

1.  在 **查询编辑器** 窗格中，执行以下操作：

    1.  在 **登录名** 字段中，输入值 **testuser**。

    1.  在 **密码** 字段中，输入值 **TestPa$$w0rd**。

    1.  选择 **确定**。

1.  在打开的查询编辑器中，输入以下查询：

```
SELECT * FROM AdventureWorks.dbo.Models
```

1.  选择 **运行** 以执行查询。

1.  查看查询的结果。

    > **注意**： 此查询将返回将显示在 Web 应用程序主页上的模型列表。

1.  在查询编辑器中，将现有查询替换为以下查询：

```
SELECT * FROM AdventureWorks.dbo.Products
```

1.  选择 **运行** 以执行查询。

1.  查看查询的结果。

    > **注意**：此查询将返回与每个模型关联的产品列表。

#### 回顾

在本练习中，你导入了将与 Web 应用程序一起使用的所有资源。

### 练习 3：打开并配置 .NET Core Web 应用程序

#### 任务 1：打开并构建 Web 应用程序

1.  在 **启动** 屏幕上，选择 **Visual Studio Code** 磁贴。

1.  在 **文件** 菜单上，选择 **打开文件夹**。

1.  在打开的 **文件资源管理器** 窗格中，转到 **Allfiles (F):\\Allfiles\\03\\Starter\\AdventureWorks**，然后选择 **选择文件夹**。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以生成 .NET Core Web 应用程序：

```
dotnet build
```

    > **注意**： ``dotnet build``命令将在生成文件夹中的所有项目之前自动还原所有丢失的 NuGet 包。

1.  查看在终端上打印的生成结果。生成应成功完成，不会出现错误或警告消息。

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 2：更新 SQL 连接字符串

1.  在 “Visual Studio Code” 窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Web** 项目。

1.  双击 **appsettings.json** 文件。

1.  在 JSON 对象的第 3 行中，找到 **ConnectionStrings.AdventureWorksSqlContext** 路径。注意当前值为空：

```
"ConnectionStrings": {
    "AdventureWorksSqlContext": "",
    ...
},
```

1.  通过将 **AdventureWorksSqlContext** 属性的值设置为你之前在本实验中记录的 **SQL 数据库** 的 **ADO.NET （SQL 身份验证）连接字符串** 来更新其值

    > **注意**： 请务必在此处使用更新后的连接字符串。从门户复制的原始连接字符串将不具有连接到 SQL 数据库所需的用户名和密码。

1.  保存 **appsettings.json** 文件。

#### 任务 3：更新 blob 基本 URL

1.  在 JSON 对象的第 8 行中，找到 **Settings.BlobContainerUrl** 路径。注意当前值为空：

```
"Settings": {
    "BlobContainerUrl": "",
    ...
}
```

1.  通过将 **BlobContainerUrl** 属性的值设置为你之前在本实验中记录的名为 **images** 的 **Azure 存储** blob 容器的 **URL** 属性来更新该值。

1.  保存 **appsettings.json** 文件。

#### 任务 4：验证 Web 应用程序

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Web** 文件夹：

```
cd .\AdventureWorks.Web\
```

1.  在命令提示符中，输入以下命令并按 Enter，以运行 .NET Core Web 应用程序：

```
dotnet run
```

    > **注意**： ``dotnet run`` 命令将自动生成对项目的更改，然后在不连接调试程序的情况下启动 Web 应用程序。此命令将输出正在运行的应用程序的 URL 和所有已分配端口的 URL。

1.  在任务栏上，选择 **Microsoft Edge** 图标。

1.  在打开的浏览器窗口中，导航到当前正在运行的 Web 应用程序 (<http://localhost:5000>)。

1.  在 Web 应用程序中，查看首页上显示的模型列表。

1.  找到 **水壶** 模型并选择 **查看详细信息**。

1.  在 **水壶** 产品详细信息页面，选择 **添加到购物车**。

1.  查看结帐功能当前是否处于禁用状态。

    > **注意**： 目前，你只实现了产品页面功能。你将在本实验的后面部分实现结帐逻辑。

1.  关闭显示 Web 应用程序的浏览器窗口。

1.  返回 **Visual Studio Code** 窗口。

1.  返回 **Visual Studio Code** 窗口，选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 回顾

在本练习中，你配置了 ASP.NET Core Web 应用程序以连接到 Azure 中的资源。

### 练习 4：将 SQL 数据迁移到 Azure Cosmos DB

#### 任务 1：创建迁移项目

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以在具有相同名称的文件夹中创建一个名为 **AdventureWorks.Migrate** 的新的 .NET 项目：

```
dotnet new console --name AdventureWorks.Migrate --langVersion 7.1
```

    > **注意**：``dotnet new`` 命令将在与项目同名的文件夹中创建一个新的 **控制台** 项目。

1.  在命令提示符中，输入以下命令并按 Enter，以添加对现有 **AdventureWorks.Models** 项目的引用：

```
dotnet add .\AdventureWorks.Migrate\AdventureWorks.Migrate.csproj reference .\AdventureWorks.Models\AdventureWorks.Models.csproj
```

    > **注意**： ``dotnet add reference`` 命令将添加对 **AdventureWorks.Models** 项目中包含的模型类的引用。

1.  在命令提示符中，输入以下命令并按 Enter，以添加对现有 **AdventureWorks.Context** 项目的引用：

```
dotnet add .\AdventureWorks.Migrate\AdventureWorks.Migrate.csproj reference .\AdventureWorks.Context\AdventureWorks.Context.csproj
```

    > **注意**： ``dotnet add reference`` 命令将添加对 **AdventureWorks.Context** 项目中包含的上下文类的引用。

1.  在命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Migrate** 文件夹：

```
cd .\AdventureWorks.Migrate
```

1.  在命令提示符中，输入以下命令并按 Enter，以从 NuGet 导入 **2.2.6** 版本的 **Microsoft.EntityFrameworkCore.SqlServer**：

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.6
```

    > **注意**： ``dotnet add package`` 命令将从 **NuGet** 添加 **Microsoft.EntityFrameworkCore.SqlServer(https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/2.2.6)**包。

1.  在命令提示符中，输入以下命令并按 Enter，以从 NuGet 添加 **3.0.0** 版本的 **Microsoft.Azure.Cosmos**：

```
dotnet add package Microsoft.Azure.Cosmos --version 3.0.0
```

    > **注意**： ``dotnet add package`` 命令将从 **NuGet** 添加 **Microsoft.Azure.Cosmos(https://www.nuget.org/packages/Microsoft.Azure.Cosmos/3.0.0)**包。

1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 2：创建 .NET 类 

1.  在 “Visual Studio Code” 窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Migrate** 项目。

1.  双击 **Program.cs** 文件。

1.  在 **Program.cs** 文件的代码编辑器选项卡中，删除现有文件中的所有代码。

1.  添加以下代码行以从引用的 **AdventureWorks.Models** 和 **AdventureWorks.Context** 项目中导入 **AdventureWorks.Models** 和 **AdventureWorks.Context** 命名空间：

```
using AdventureWorks.Context;
using AdventureWorks.Models;
```

1.  添加以下代码行，通过从 NuGet 导入的 **Microsoft.Azure.Cosmos** 包导入 **Microsoft.Azure.Cosmos** 命名空间：

```
using Microsoft.Azure.Cosmos;
```

1.  添加以下代码行，通过从 NuGet 导入的 **Microsoft.EntityFrameworkCore.SqlServer** 包导入 **Microsoft.EntityFrameworkCore** 命名空间：

```
using Microsoft.EntityFrameworkCore;
```

1.  添加以下代码行，为此文件将使用的内置命名空间添加 **using** 指令：

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
```

1.  输入以下代码，创建一个新的 **Program** 类：

```
public class Program
{
}
```

1.  在 **Program** 类中，输入以下代码行以创建一个名为 **sqlDBConnectionString** 的新字符串常量：

```
private const string sqlDBConnectionString = "";
```

1.  通过将 **sqlDBConnectionString** 字符串常量的值设置为你之前在本实验中记录的 **SQL 数据库** 的 **ADO.NET（SQL 身份验证）连接字符串** 来更新字符串常量。

    > **注意**： 请务必在此处使用更新后的连接字符串。从门户复制的原始连接字符串将不具有连接到 SQL 数据库所需的用户名和密码。

1.  在 **Program** 类中，输入以下代码行以创建一个名为 **cosmosDBConnectionString** 的新字符串常量： 

```
private const string cosmosDBConnectionString = "";
```

1.  通过将 **cosmosDBConnectionString**字符串常量的值设置为你在本实验中记录的 **Azure Cosmos DB 帐户** 的 **主连接字符串** 来更新该字符串常量。

1.  在 **Program** 类中，输入以下代码以创建新的异步 **Main** 方法：

```
public static async Task Main(string[] args)
{
}
```

1.  在 **Main** 方法中，添加以下代码行以向控制台输出介绍性消息：

```
await Console.Out.WriteLineAsync("Start Migration");
```

1.  保存 **Program.cs** 文件。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Migrate** 文件夹：

```
cd .\AdventureWorks.Migrate
```

1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 4：使用 Entity Framework 获取 SQL 数据库记录

1.  在 **Program.cs** 文件内 **Program** 类的 **Main** 方法中，添加以下代码行以创建 **AdventureWorksSqlContext** 类的新实例，该类传入 **sqlDBConnectionString** 变量作为连接字符串值：

```
AdventureWorksSqlContext context = new AdventureWorksSqlContext(sqlDBConnectionString);
```

1.  在 **Main** 方法中，添加以下代码块以发出 LINQ 查询，以从数据库中获取所有 **模型** 和子 **产品**，并将其存储在内存中 **List<>** 集合中：

```
List<Model> items = await context.Models
    .Include(m => m.Products)
    .ToListAsync<Model>();
```

1.  在 **Main** 方法中，添加以下代码行以输出从 **Azure SQL 数据库** 导入的记录数：

```
await Console.Out.WriteLineAsync($"Total Azure SQL DB Records: {items.Count}");
```

1.  保存 **Program.cs** 文件。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Migrate** 文件夹：

```
cd .\AdventureWorks.Migrate
```
    
1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

    > **注意**：如果出现任何生成错误，请查看位于 **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\AdventureWorks\\AdventureWorks.Migrate** 文件夹中的 **Program.cs** 文件。

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 5：将项目插入 Azure Cosmos DB

1.  在 **Program.cs** 文件内 **Program** 类的 **Main** 方法中，添加以下代码行以创建 **CosmosClient** 类的新实例，该类传入 **cosmosDBConnectionString** 变量作为连接字符串值：

```
CosmosClient client = new CosmosClient(cosmosDBConnectionString);
```

1.  如果 Azure Cosmos DB 帐户中还没有 **数据库**，请在 **Main**方法中添加以下代码行，以创建一个名为 **Retail** 的新数据库：

```
Database database = await client.CreateDatabaseIfNotExistsAsync("Retail");
```

1.  如果 Azure Cosmos DB 帐户中还没有 **容器**，请在 **Main** 方法中添加以下代码块，以创建一个名为 **Online** 的新容器，其分区键路径为 **/Category**，吞吐量为 **1000 RU**：

```
 Container container = await database.CreateContainerIfNotExistsAsync("Online",
    partitionKeyPath: $"/{nameof(Model.Category)}",
    throughput: 1000
);
```

1.  在 **Main** 方法中，添加以下代码行，以创建一个名为 **计数** 的 **int** 变量：

```
int count = 0;
```

1.  在 **Main** 方法中，添加以下代码块，以创建一个循环访问了 **items** 集合中的对象的 **foreach** 循环：

```
foreach（“items”中的 var 项）
{
}
```

1.  在 **Main** 方法中包含的 **foreach** 循环中，添加以下代码行，以将对象更新插入 Azure Cosmos DB 集合中，并将结果保存在名为 **document** 的变量中，变量类型为 **ItemResponse<>**：

```
ItemResponse<Model> document = await container.UpsertItemAsync<Model>(item);
```

1.  在 **Main** 方法中包含的 **foreach** 循环中，添加以下代码行，以输出每个更新插入操作的 **活动 ID**：

```
await Console.Out.WriteLineAsync($"Upserted document #{++count:000} [Activity Id: {document.ActivityId}]");
```

1.  返回到 **Main** 方法中（foreach 循环外），添加以下代码行，以输出导出到 **Azure Cosmos DB** 的文档数：

```
await Console.Out.WriteLineAsync($"Total Azure Cosmos DB Documents: {count}");
```

1.  保存 **Program.cs** 文件。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Migrate** 文件夹：

```
cd .\AdventureWorks.Migrate
```
    
1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

    > **注意**：如果出现任何生成错误，请查看位于 **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\AdventureWorks\\AdventureWorks.Migrate** 文件夹中的 **Program.cs** 文件。

#### 任务 6：执行迁移

1.  在打开的命令提示符中，输入以下命令并按 Enter，以运行 .NET Core Web 应用程序：

```
dotnet run
```

    > **注意**： ``dotnet run`` 命令将启动控制台应用程序。

1.  查看输出到屏幕上的各种数据，其中包括初始 SQL 记录计数、单个更新插入活动标识符、最终 Azure Cosmos DB 文档计数。

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 7：验证迁移

1.  返回显示 **Azure 门户** 的 **Microsoft Edge** 浏览器窗口。

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验中创建的 **PolyglotData** 资源组。

1.  在 **PolyglotData** 边栏选项卡中，选择你之前在本实验中创建的 **polycosmos\** Azure Cosmos DB 帐户。

1.  在 **Azure Cosmos DB 帐户** 边栏选项卡中，找到并选择边栏选项卡左侧的 **查询资源管理器** 链接。

1.  在 **查询资源管理器** 窗格中，展开 **零售** 数据库节点。

1.  展开 **联机** 容器节点。

1.  选择 **新建 SQL 查询**。

    > **注意**： 此选项的标签可能会隐藏。可以通过将鼠标悬停在 **数据资源管理器** 窗格顶部的图标上来查看。

1.  在显示的查询选项卡中，输入以下文本：

```
SELECT * FROM models
```

1.  选择 **执行查询**。

1.  查看查询返回的 JSON 模型列表。

1.  返回查询编辑器，将现有文本替换为以下文本：

```
SELECT VALUE COUNT(1) FROM models
```

1.  选择 **执行查询**。

1.  查看 **COUNT** 聚合运算的结果。

1.  返回 **Visual Studio Code** 窗口。

#### 回顾

在本练习中，你使用了 Entity Framework 和用于 Azure Cosmos DB 的 .NET SDK 将数据从 Azure SQL 数据库迁移到了 Azure Cosmos DB。

### 练习 5：使用 .NET 访问 Azure Cosmos DB

#### 任务 1：使用 Cosmos SDK 和参考更新库

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Context** 文件夹：

```
cd .\AdventureWorks.Context\
```

1.  在命令提示符中，输入以下命令并按 Enter，以从 NuGet 导入 **Microsoft.Azure.Cosmos**：

```
dotnet add package Microsoft.Azure.Cosmos --version 3.0.0
```

    > **注意**： ``dotnet add package`` 命令将从 **NuGet** 添加 **Microsoft.Azure.Cosmos(https://www.nuget.org/packages/Microsoft.Azure.Cosmos/3.0.0)**包。

1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 2：编写 .NET 代码以连接到 Azure Cosmos DB

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Context** 项目。

1.  访问上下文菜单或右键单击 **AdventureWorks.Context** 文件夹节点，然后选择 **新建文件**。

1.  在出现的提示中，输入值 **AdventureWorksCosmosContext.cs**。

1.  在 **AdventureWorksCosmosContext.cs** 文件的代码编辑器选项卡中，添加以下代码行，以从引用的 **AdventureWorks.Models** 项目中导入 **AdventureWorks.Models** 命名空间：

```
using AdventureWorks.Models;
```

1.  添加以下代码行，通过从 NuGet 导入的 **Microsoft.Azure.Cosmos** 包导入 **Microsoft.Azure.Cosmos** 和 **Microsoft.Azure.Cosmos.Linq** 命名空间：

```
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
```

1.  添加以下代码行，为此文件将使用的内置命名空间添加 **using** 指令：

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
```

1.  输入以下代码，以添加 **AdventureWorks.Context** 命名空间块：

```
namespace AdventureWorks.Context
{
}
```

1.  在 **AdventureWorks.Context** 命名空间中，输入以下代码，以创建新的 **AdventureWorksCosmosContext** 类：

```
public class AdventureWorksCosmosContext
{
}
```

1.  通过添加表示此类将实现 **IAdventureWorksProductContext** 接口的说明来更新 **AdventureWorksCosmosContext** 类的声明：

```
public class AdventureWorksCosmosContext : IAdventureWorksProductContext
{
}
```

1.  在 **AdventureWorksCosmosContext** 类中，输入以下代码行，以创建一个名为 **_container** 的新的只读 **Container** 变量：

```
private readonly Container _container;
```

1.  在 **AdventureWorksCosmosContext** 类中，添加一个新的使用以下签名的构造函数：

```
public AdventureWorksCosmosContext(string connectionString, string database = "Retail", string container = "Online")
{
}
```

1.  在构造函数中，添加以下代码块以创建 **CosmosClient** 类的新实例，然后从客户端获取 **数据库** 和 **容器** 实例：

```
_container = new CosmosClient(connectionString)
    .GetDatabase(database)
    .GetContainer(container);
```

1.  在 **AdventureWorksCosmosContext** 类中，添加一个新的使用以下签名的 **FindModelAsync** 方法：

```
public async Task<Model> FindModelAsync(Guid id)
{
}
```

1.  在 **FindModelAsync** 方法中，添加以下代码块以创建一个 LINQ 查询，并将其转换为迭代器，循环访问结果集，然后返回结果集中的单个项：

```
var iterator = _container.GetItemLinqQueryable<Model>()
    .Where(m => m.id == id)
    .ToFeedIterator<Model>();

List<Model> matches = new List<Model>();
while (iterator.HasMoreResults)
{
    var next = await iterator.ReadNextAsync();
    matches.AddRange(next);
}

return matches.SingleOrDefault();
```

1.  在 **AdventureWorksCosmosContext** 类中，添加一个新的使用以下签名的 **GetModelsAsync** 方法：

```
public async Task<List<Model>> GetModelsAsync()
{
}
```

1.  在 **GetModelsAsync** 方法中，添加以下代码块以执行 SQL 查询，获取查询结果迭代器，循环访问结果集，然后返回所有结果的联合：

```
string query = $@"SELECT * FROM items";

var iterator = _container.GetItemQueryIterator<Model>(query);

List<Model> matches = new List<Model>();
while (iterator.HasMoreResults)
{
    var next = await iterator.ReadNextAsync();
    matches.AddRange(next);
}

return matches;
```

1.  在 **AdventureWorksCosmosContext** 类中，添加一个新的使用以下签名的 **FindProductAsync** 方法：

```
public async Task<Product> FindProductAsync(Guid id)
{
}
```

1.  在 **FindProductAsync** 方法中，添加以下代码块以执行 SQL 查询，获取查询结果迭代器，循环访问结果集，然后返回结果集中的单个项：

```
string query = $@"SELECT VALUE products
                    FROM models
                    JOIN products in models.Products
                    WHERE products.id = '{id}'";

var iterator = _container.GetItemQueryIterator<Product>(query);

List<Product> matches = new List<Product>();
while (iterator.HasMoreResults)
{
    var next = await iterator.ReadNextAsync();
    matches.AddRange(next);
}

return matches.SingleOrDefault();
```

1.  保存 **AdventureWorksCosmosContext.cs** 文件。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Context** 文件夹：

```
cd .\AdventureWorks.Context
```
    
1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

    > **注意**：如果出现任何生成错误，请查看位于 **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\AdventureWorks\\AdventureWorks.Context** 文件夹中的 **AdventureWorksCosmosContext.cs**文件。

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 3：更新 Azure Cosmos DB 连接字符串

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Web** 项目。

1.  双击 **appsettings.json**文件。

1.  在 JSON 对象的第 4 行中，找到 **ConnectionStrings.AdventureWorksCosmosContext** 路径。注意当前值为空：

```
"ConnectionStrings": {
    ...
    "AdventureWorksCosmosContext": "",
    ...
},
```

1.  通过将 **AdventureWorksCosmosContext** 属性的值设置为你之前在本实验中记录的 **Azure Cosmos DB 帐户** 的 **主连接字符串** 来更新其值。

1.  保存 **appsettings.json** 文件。

#### 任务 4：更新 .NET 应用程序启动逻辑

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Web** 项目。

1.  双击 **Startup.cs** 文件。

1.  在 **Startup** 类中，找到现有的 **ConfigureProductService** 方法。

```
public void ConfigureProductService(IServiceCollection services)
{
    services.AddScoped<IAdventureWorksProductContext, AdventureWorksSqlContext>(provider =>
        new AdventureWorksSqlContext(
            _configuration.GetConnectionString(nameof(AdventureWorksSqlContext))
        )
    );
}
```

    > **注意**：当前的产品服务使用 SQL 作为其数据库。

1.  在 **ConfigureProductService** 方法中，删除所有现有的代码行：

```
public void ConfigureProductService(IServiceCollection services)
{
}
```

1.  在 **ConfigureProductService** 方法中，添加以下代码块，以将产品提供程序更改为你之前在本实验中创建的 **AdventureWorksCosmosContext** 实现：

```
services.AddScoped<IAdventureWorksProductContext, AdventureWorksCosmosContext>(provider =>
    new AdventureWorksCosmosContext(
        _configuration.GetConnectionString(nameof(AdventureWorksCosmosContext))
    )
);
```

1.  保存 **Startup.cs** 文件。

#### 任务 5：验证 .NET 应用程序是否成功连接到 Azure Cosmos DB

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Web** 文件夹：

```
cd .\AdventureWorks.Web\
```

1.  在命令提示符中，输入以下命令并按 Enter，以运行 .NET Core Web 应用程序：

```
dotnet run
```

    > **注意**： ``dotnet run``命令将自动生成对项目的更改，然后在不连接调试程序的情况下启动 Web 应用程序。此命令将输出正在运行的应用程序的 URL 和所有已分配端口的 URL。

1.  在任务栏上，选择 **Microsoft Edge** 图标。

1.  在打开的浏览器窗口中，导航到当前正在运行的 Web 应用程序 (<http://localhost:5000>)。

1.  在 Web 应用程序中，查看首页上显示的模型列表。

1.  找到 **Touring-1000** 模型并选择 **查看详细信息**。

1.  在 **Touring-1000** 产品详细信息页面上，执行以下操作：

    1.  在 **选择选项** 列表中，选择 **Touring-1000 Yellow, 50, $2,384.07**。
    
    1.  选择 **添加到购物车**。

1.  注意到结帐功能仍处于禁用状态。

    > **注意**： 在下一个练习中，你将实现结帐逻辑。

1.  关闭显示 Web 应用程序的浏览器窗口。

1.  返回 **Visual Studio Code** 窗口。

1.  返回 **Visual Studio Code** 窗口，选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 回顾

在本练习中，你编写了 C# 代码以使用 .NET SDK 查询 Azure Cosmos DB 集合。

### 练习 6：使用 .NET 访问 Azure Cache for Redis

#### 任务 1：使用 StackExchange.Redis SDK 和参考更新库

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Context** 文件夹：

```
cd .\AdventureWorks.Context\
```

1.  在命令提示符中，输入以下命令并按 Enter，以从 NuGet 导入 **Newtonsoft.Json**：

```
dotnet add package Newtonsoft.Json --version 12.0.2
```

    > **注意**： ``dotnet add package`` 命令将从 NuGet 添加 **[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/12.0.2)**包。

1.  在命令提示符中，输入以下命令并按 Enter，以从 NuGet 导入 **StackExchange.Redis**：

```
dotnet add package StackExchange.Redis --version 2.0.601
```

    > **注意**：``dotnet add package`` 命令将从 NuGet 添加 **[StackExchange.Redis](https://www.nuget.org/packages/StackExchange.Redis/2.0.601)**包。

1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 2：编写 .NET 代码以连接到 Azure Cache for Redis

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Context** 项目。

1.  访问上下文菜单或右键单击 **AdventureWorks.Context** 文件夹节点，然后选择 **新建文件**。

1.  在出现的提示中，输入值 **AdventureWorksRedisContext.cs**。

1.  在 **AdventureWorksRedisContext.cs**文件的代码编辑器选项卡中，添加以下代码行，以从引用的 **AdventureWorks.Models** 项目中导入 **AdventureWorks.Models** 命名空间：

```
using AdventureWorks.Models;
```

1.  添加以下代码行，通过从 NuGet 导入的 **Newtonsoft.Json** 包导入 **Newtonsoft.Json** 命名空间：

```
using Newtonsoft.Json;
```

1.  添加以下代码行，通过从 NuGet 导入的 **StackExchange.Redis** 包导入 **StackExchange.Redis** 命名空间：

```
using StackExchange.Redis;
```

1.  添加以下代码行，为此文件将使用的内置命名空间添加 **using** 指令：

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
```

1.  输入以下代码，以添加 **AdventureWorks.Context** 命名空间块：

```
namespace AdventureWorks.Context
{
}
```

1.  在 **AdventureWorks.Context** 命名空间中，输入以下代码以创建一个新的 **AdventureWorksRedisContext** 类：

```
public class AdventureWorksRedisContext
{
}
```

1.  通过添加表示此类将实现 **IAdventureWorksCheckoutContext** 接口的说明来更新 **AdventureWorksRedisContext** 类的声明：

```
public class AdventureWorksRedisContext : IAdventureWorksCheckoutContext
{
}
```

1.  在 **AdventureWorksRedisContext** 类中，输入以下代码行，以创建一个名为 **_database** 的新的只读 **IDatabase** 变量：

```
private readonly IDatabase _database;
```

1.  在 **AdventureWorksRedisContext** 类中，添加一个新的使用以下签名的构造函数：

```
public AdventureWorksRedisContext(string connectionString)
{        
}
```

1.  在构造函数中，添加以下代码块以创建 **ConnectionMultiplexer** 类的新实例，然后获取数据库实例：

```
ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(connectionString);
_database = connection.GetDatabase();
```

1.  在 **AdventureWorksRedisContext** 类中，添加一个新的使用以下签名的 **AddProductToCartAsync** 方法：

```
public async Task AddProductToCartAsync(string uniqueIdentifier, Product product)
{        
}
```

1.  在 **AddProductToCartAsync**方法中，添加以下代码块，以从密钥中获取当前值。如果还没有列表，请创建一个新的列表，并将产品添加到列表中，然后将该列表作为密钥的新值存储在数据库中：
    
```
RedisValue result = await _database.StringGetAsync(uniqueIdentifier);
List<Product> products = new List<Product>();
if (!result.IsNullOrEmpty)
{
    List<Product> parsed = JsonConvert.DeserializeObject<List<Product>>(result.ToString());
    products.AddRange(parsed);
}
products.Add(product);
string json = JsonConvert.SerializeObject(products);
await _database.StringSetAsync(uniqueIdentifier, json);
```

1.  在 **AdventureWorksRedisContext** 类中，添加一个新的使用以下签名的 **GetProductsInCartAsync** 方法：

```
public async Task<List<Product>> GetProductsInCartAsync(string uniqueIdentifier)
{        
}
```

1.  在 **GetProductsInCartAsync** 方法中，添加以下代码行以从数据库中获取列表，并将 JSON 值分析为 **Product** 实例的集合：
    
```    
string json = await _database.StringGetAsync(uniqueIdentifier);
List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json ?? "[]");
return products;
```

1.  在 **AdventureWorksRedisContext** 类中，添加一个新的使用以下签名的 **ClearCart** 方法：

```
public async Task ClearCart(string uniqueIdentifier)
{        
}
```

1.  在 **ClearCart** 方法中，添加以下代码行以从数据库中删除密钥及其关联的值：
    
```
await _database.KeyDeleteAsync(uniqueIdentifier);
```

1.  保存 **AdventureWorksRedisContext.cs** 文件。

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Context** 文件夹：

```
cd .\AdventureWorks.Context
```
    
1.  在命令提示符中，输入以下命令并按 Enter，以构建 .NET Core Web 应用程序：

```
dotnet build
```

    > **注意**： 如果出现任何生成错误，请查看位于 **Allfiles (F):\\Allfiles\\Labs\\03\\Solution\\AdventureWorks\\AdventureWorks.Context** 文件夹中的 **AdventureWorksRedisContext.cs** 文件。

1.  选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 任务 3：更新 Redis 连接字符串

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Web** 项目。

1.  双击 **appsettings.json** 文件。

1.  在 JSON 对象的第 4 行中，找到 **ConnectionStrings.AdventureWorksRedisContext** 路径。注意当前值为空：

```
"ConnectionStrings": {
    ...
    "AdventureWorksRedisContext": ""
},
```

1.  通过将 **AdventureWorksRedisContext** 属性的值设置为你之前在本实验中记录的 **Azure Cache for Redis** 实例的 **主连接字符串 (StackExchange.Redis)** 来更新该值。

1.  在 JSON 对象的第 9 行中，找到 **Settings.CartAvailable** 路径。注意当前值为 **false**：

```
"Settings": {
    ...
    "CartAvailable": false,
    ...
}
```

1.  通过将 **CartAvailable** 属性的值设置为 **true** 来更新该值：

```
"CartAvailable": true,
```

1.  保存 **appsettings.json** 文件。

#### 任务 4：更新 .NET 应用程序启动逻辑

1.  在“Visual Studio Code”窗口的 **Explorer** 窗格中，展开 **AdventureWorks.Web** 项目。

1.  双击 **Startup.cs** 文件。

1.  在 **Startup** 类中，找到现有的 **ConfigureCheckoutService** 方法：

```
public void ConfigureCheckoutService(IServiceCollection services)
{
    services.AddScoped<IAdventureWorksCheckoutContext>(provider =>
        new Mock<IAdventureWorksCheckoutContext>().Object
    );
}
```

    > **注意**： 当前的结帐服务使用一个模拟作为其数据库。

1.  在 **ConfigureCheckoutService** 方法中，删除所有现有的代码行：

```
public void ConfigureCheckoutService(IServiceCollection services)
{
}
```

1.  在 **ConfigureCheckoutService** 方法中，添加以下代码块，以将结帐提供程序更改为你之前在本实验中创建的 **AdventureWorksRedisContext** 实现：

```
services.AddScoped<IAdventureWorksCheckoutContext, AdventureWorksRedisContext>(provider =>
    new AdventureWorksRedisContext(
        _configuration.GetConnectionString(nameof(AdventureWorksRedisContext))
    )
);
```

1.  保存 **Startup.cs** 文件。

#### 任务 5：验证 .NET 应用程序是否成功连接到 Azure Cache for Redis

1.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击 **资源管理器** 窗格，然后选择 **在终端中打开**。

1.  在打开的命令提示符中，输入以下命令并按 Enter，以将终端上下文切换到 **AdventureWorks.Web** 文件夹：

```
cd .\AdventureWorks.Web\
```

1.  在命令提示符中，输入以下命令并按 Enter，以运行 .NET Core Web 应用程序：

```
dotnet run
```

    > **注意**： ``dotnet run``命令将自动生成对项目的更改，然后在不连接调试程序的情况下启动 Web 应用程序。此命令将输出正在运行的应用程序的 URL 和所有已分配端口的 URL。

1.  在任务栏上，选择 **Microsoft Edge** 图标。

1.  在打开的浏览器窗口中，导航到当前正在运行的 Web 应用程序 (<http://localhost:5000>)。

1.  在 Web 应用程序中，查看首页上显示的模型列表。

1.  找到 **Mountain-400-W** 模型并选择 **查看详细信息**。

1.  在 **Mountain-400-W** 产品详细信息页面上，执行以下操作：

    1.  在 **选择选项** 列表中，选择 **Mountain-400-W Silver, 40, $769.49**。
    
    1.  选择 **添加到购物车**。

1.  在购物车页面上，查看购物车中的内容，然后选择 **结帐**。

1.  在结帐页面上，查看最后的收据。

1.  选择页面顶部的 **购物车** 图标。

1.  在购物车页面上，查看空的购物车。

1.  关闭显示 Web 应用程序的浏览器窗口。

1.  返回 **Visual Studio Code** 窗口，选择 **垃圾箱** 图标以释放当前打开的终端和所有关联的进程。

#### 回顾

在本练习中，你使用了 C# 代码存储数据以及从 Azure Cache for Redis 存储中检索数据。

### 练习 7：清理订阅 

#### 任务 1：打开 Azure Cloud Shell

1.  在门户顶部，选择 **Cloud Shell** 图标以打开一个新的 shell 实例。

    > **注意**： **Cloud Shell** 图标使用大于符号和下划线字符表示。

1.  如果这是你第一次使用订阅打开 **Cloud Shell**，系统将显示 **欢迎使用 Azure Cloud Shell 向导**，帮助你在第一次使用时配置 **Cloud Shell**。在向导中执行以下操作：
    
    1.  系统将出现一个对话框，提示你创建新的存储帐户以开始使用 shell。接受默认设置并选择 **创建存储**。
    
    1.  等待 **Cloud Shell** 完成首次设置过程后，再继续本实验。

    > **注意**：如果你没有看到 **Cloud Shell**的配置选项，这很可能是因为你在本课程实验中使用的是现有订阅。实验是在你使用的是新订阅的假设下编写的。

1.  在门户底部的 **Cloud Shell** 命令提示符中，输入以下命令，然后按 Enter 列出订阅中的所有资源组：

```
az group list
```
1.  在提示符中，键入以下命令，然后按 Enter 查看用于删除资源组的可用命令列表：

```
az group delete --help
```

#### 任务 2：删除资源组

1.  在提示符中，键入以下命令，然后按 Enter 删除 **PolyglotData** 资源组：

```
az group delete --name PolyglotData --no-wait --yes
```
    
1.  关闭门户底部的 **Cloud Shell** 窗格。

#### 任务 3：关闭活动应用程序

1.  关闭当前正在运行的 **Microsoft Edge** 应用程序。

1.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你通过删除本实验中使用的 **资源组** 清理了订阅。
