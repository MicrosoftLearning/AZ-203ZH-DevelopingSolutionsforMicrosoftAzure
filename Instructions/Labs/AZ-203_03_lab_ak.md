---
lab:
    title: '实验室：构造多语言数据解决方案'
    type: '答案'
    module: '模块 3：开发 Azure 存储'
---

# 实验室：构造多语言数据解决方案
# 学生实验室答案

## Microsoft Azure 用户界面

鉴于 Microsoft 云工具的动态特性，Azure 用户界面 (UI) 在此培训内容开发之后可能会发生更改。这些更改可能会导致实验室说明和步骤不能正确匹配。

一旦 Microsoft 通过社区注意到必要更改，将会立即更新此培训课程。但由于云更新频繁，你可能会在此培训内容更新前遇到 UI 更改。**如果发生这种情况，请根据需要适更改并在实验室中完成这些更改。**

## 说明

### 开始前

#### 登录实验室虚拟机

  - 使用以下凭据登录到 **Windows 10** 虚拟机：
    
      - **用户名**：Admin
    
      - **密码**：Pa55w.rd

> > **注**：讲师将为你提供实验室虚拟机登录说明。

#### 查看已安装的应用

  - 观察位于 **Windows 10** 桌面底部的任务栏。任务栏包含将在本实验室中使用的应用程序图标：
    
      - Microsoft Edge
    
      - 文件资源管理器
    
      - Visual Studio Code

#### 下载实验室文件

1.  在任务栏上，选择 **Windows PowerShell** 图标。

2.  在 PowerShell 命令提示符中，将当前工作目录更改为 **Allfiles (F):\\** 路径：

    ```
    cd F:
    ```

3.  在命令提示符中，输入以下命令并按 Enter 键以将 GitHub 上托管的 **microsoftlearning/AZ-203-DevelopingSolutionsForAzure** 项目克隆到 **Labfiles** 目录：

    ```
    git clone --depth 1 --no-checkout https://github.com/microsoftlearning/AZ-203-DevelopingSolutionsForMicrosoftAzure .
    ```

4.  在命令提示符中，输入以下命令并按 **Enter** 键以签出完成 **AZ-203.02** 实验室所必需的实验室文件：

    ```
    git checkout master -- Allfiles/*
    ```

5.  关闭当前正在运行的 **Windows PowerShell** 命令提示应用程序。

### 练习 1：在 Azure 中创建数据库资源

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

2.  在打开的浏览器窗口中，导航到 **Azure 门户** ([portal.azure.com](https://portal.azure.com))。

3.  输入 Microsoft 帐户的 **电子邮件地址**。

4.  选择“**下一步**”。

5.  输入 Microsoft 帐户的 **密码**。

6.  选择“**登录**”。

> > 注：如果这是你第一次登录 **Azure 门户**，则会出现一个对话框，提供门户教程。选择“**开始使用**”以跳过教程并开始使用门户。

#### 任务 2：创建 SQL 数据库资源

1.  在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

2.  在“**所有服务**”边栏选项卡中，选择**“SQL Server”**。

3.  在“**SQL Server**”边栏选项卡中，查看 SQL Server 实例列表。

4.  在“**存储帐户**”边栏选项卡顶部，选择“**添加**”。

5.  在“**SQL Server（仅逻辑服务器）**”边栏选项卡中，执行以下操作：
    
    1.  在“**服务器名称**”字段中，输入 **polysqlsrvr\[your name in lowercase\]**。
    
    2.  在“**服务器管理员登录**”字段中，输入值 **testuser**。
    
    3.  在“**密码**”字段中，输入值 **TestPa$$w0rd**。
    
    4.  在“**确认密码**”字段中，再次输入值 **TestPa$$w0rd**。
    
    5.  将“**订阅**”下拉菜单保留设置为默认值。
    
    6.  在“**资源组**”部分，选择“**新建**”，输入 **PolyglotData**，然后选择“**确定**”。
    
    7.  在“**位置**”下拉列表中，选择“**美国东部**”选项。
    
    8.  在“**允许 Azure 服务访问服务器**”部分，确保选中该复选框。
    
    9.  在“**高级数据安全**”部分，选择“**以后再说**”选项。
    
    10. 选择“**创建**”。

6.  等待创建任务完成后，再继续本实验室。

7.  在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

8.  在“**所有服务**”边栏选项卡中，选择“**SQL 数据库**”。

9.  在“**SQL 数据库**”边栏选项卡中，查看 SQL数据库实例列表。

10. 在“**SQL 数据库**”边栏选项卡顶部，选择“**添加**”。

11. 在“**创建 SQL 数据库**”边栏选项卡中，观察边栏选项卡顶部的选项卡，如“**基本**”、“**其他设置**”和“**标记**”。

> 注：每个选项卡代表工作流中创建新“**Azure SQL 数据库**”的一个步骤。你可以随时选择“**查看 + 创建**”跳过剩余标签。

12. 在“**基本**”选项卡中，执行以下操作：
    
    11. 将“**订阅**”文本框保留设置为默认值。
    
    12. 在“**资源组**”部分，从列表中选择“**PolyglotData**”。
    
    13. 在“**数据库** **名称**”文本框中，输入 **polysqldb**。
    
    14. 在“**服务器**”字段中，输入 **polysqlsrvr\[your name in lowercase\]** 选项。
    
    15. 在“**想要使用 SQL 弹性池**”部分，选择“**否**”选项。
    
    16. 将“**计算 + 存储**”选项保留设置为默认值。
    
    17. 选择“**查看 + 创建**”。

13. 在“**查看 + 创建**”选项卡中，查看在之前步骤中选择的选项。

14. 选择“**创建**”以使用指定的配置创建存储帐户。

15. 等待创建任务完成后，再继续本实验室。

16. 在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

17. 在“**所有服务**”边栏选项卡中，选择“**SQL 数据库**”。

18. 在“**SQL 数据库**”边栏选项卡中，选择名为 **polysqldb** 的 SQL 数据库实例。

19. 在“**SQL 数据库**”边栏选项卡中，找到边栏选项卡左侧的“**设置**”部分，选择“**连接字符串**”链接。

20. 在“**连接字符串**”窗格中，复制 **ADO.NET** 连接字符串的值。请务必分别使用值 testuser 和 TestPa$$w0rd,** ** 替换 *{your\_username}* 和 *{your\_password}* 占位符值。

> > 注：例如，如果复制的连接字符串为

    Server=tcp:polysqlsrvrstudent.database.windows.net,1433;Initial Catalog=polysqldb;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;,

> > 更新的连接字符串将为

    Server=tcp:polysqlsrvrstudent.database.windows.net,1433;Initial Catalog=polysqldb;Persist Security Info=False;User ID=testuser;Password=TestPa$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

21. 在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

22. 在“**所有服务**”边栏选项卡中，选择**“SQL Server”**。

23. 在“**SQL Server**”边栏选项卡中，选择具有前缀 **polysqlsrvr** 的 SQL Server 实例。

24. 在“**SQL Server**”边栏选项卡中，找到边栏选项卡左侧的“**安全性**”部分，选择“**防火墙和虚拟网络**”链接。

25. 在“**防火墙和虚拟网络**”窗格中，选择“**添加客户端 IP**”将虚拟机的 IP 地址添加到允许的 IP 地址范围列表中。

26. 在边栏选项卡顶部，单击“**保存**”。

> > 注：防火墙更改可能需要几分钟才能在服务器上更新。

27. 保存操作完成后，选择“**确定**”以关闭确认对话框。

#### 任务 3：创建 Azure Cosmos DB 帐户资源

1.  在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

2.  在“**所有服务**”边栏选项卡中，选择 **“Azure Cosmos DB”**。

3.  在“**Azure Cosmos DB**”边栏选项卡中，查看 Azure Cosmos DB 实例列表。

4.  在“**Azure Cosmos DB**”边栏选项卡顶部，选择“**添加**”。

5.  在“**创建 Azure Cosmos DB 帐户**”边栏选项卡中，观察边栏选项卡顶部的选项卡，如“**基本**”、“**网络**”和“**标记**”。

> 注：每个选项卡代表工作流中创建新“**Azure Cosmos DB 帐户**”的一个步骤。你可以随时选择“**查看 + 创建**”跳过剩余标签。

6.  在“**基本**”选项卡中，执行以下操作：
    
    1.  将“**订阅**”文本框保留设置为默认值。
    
    2.  在“**资源组**”部分，从列表中选择“**PolyglotData**”。
    
    3.  在“**帐户** **名称**”文本框中，输入 **polycosmos\[your name in lowercase\]**。
    
    4.  在“**API**”下拉列表中，选择“**核心 (SQL)**”选项。
    
    5.  在“**位置**”下拉列表中，选择“**美国东部**”地区。
    
    6.  在“**地理冗余**”部分，选择“**禁用**”选项。
    
    7.  在“**多区域写入**”部分，选择“**禁用**”选项。
    
    8.  选择“**查看 + 创建**”。

7.  在“**查看 + 创建**”选项卡中，查看在之前步骤中选择的选项。

8.  选择“**创建**”以使用指定的配置创建存储帐户。

9.  等待创建任务完成后，再继续本实验室。

10. 在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

11. 在“**所有服务**”边栏选项卡中，选择**“Azure Cosmos DB”**。

12. 在“**Azure Cosmos DB**”边栏选项卡中，选择包含前缀 **polycosmos** 的 Azure Cosmos DB 帐户实例。

13. 在“**Azure Cosmos DB 帐户**”边栏选项卡中，找到边栏选项卡左侧的“**设置**”部分，选择“**密钥**”链接。

14. 在“**密钥**”窗格中，记录“**URI**”和“**主键**”字段中的值。。你将稍后在本实验室中使用这些值。

#### 任务 4：创建 Azure 存储帐户资源

1.  在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

2.  在“**所有服务**”边栏选项卡中，选择 **“存储帐户”**。

3.  在“**存储帐户**”边栏选项卡中，查看存储实例列表。

4.  在“**存储帐户**”边栏选项卡顶部，选择“**添加**”。

5.  在“**创建存储帐户**”边栏选项卡中，观察边栏选项卡顶部的选项卡，如“**基本**”、“**高级**”和“**标记**”。

> 注：每个选项卡代表工作流中创建新“**Azure 存储帐户**”的一个步骤。你可以随时选择“**查看 + 创建**”跳过剩余标签。

6.  在“**基本**”选项卡中，执行以下操作：
    
    1.  将“**订阅**”文本框保留设置为默认值。
    
    2.  在“**资源组**”部分，从列表中选择“**PolyglotData**”。
    
    3.  在“**存储帐户** **名称**”字段中，输入 **polystor\[your name in lowercase\]**。
    
    4.  在“**位置**”下拉列表中，选择“**美国东部**”地区。
    
    5.  在“**性能**”部分，选择“**标准**”。
    
    6.  在“**帐户类型**”下拉列表中，选择 **StorageV2（通用 v2）***。*
    
    7.  在“**复制**”下拉列表中，选择“**本地冗余存储 (LRS)**”。
    
    8.  在“**访问层（默认）**”部分，确保 **热** 已选中。
    
    9.  选择“**查看 + 创建**”。

7.  在“**查看 + 创建**”选项卡中，查看在之前步骤中选择的选项。

8.  选择“**创建**”以使用指定的配置创建存储帐户。

9.  等待创建任务完成后，再继续本实验室。

10. 在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

11. 在“**所有服务**”边栏选项卡中，选择 **“存储帐户”**。

12. 在“**存储帐户**”边栏选项卡中，选择具有前缀 **polystor** 的 Azure 存储帐户实例。

13. 在“**存储帐户**”边栏选项卡中，找到边栏选项卡左侧的“**设置**”部分，选择“**访问密钥**”链接。

14. 在“**访问密钥**”边栏选项卡中，选择任意一个密钥并记录“**连接字符串**”文本框中的值。你将稍后在本实验室中使用此值。

#### 回顾

在本练习中，你创建了多语言数据解决方案所需的所有 Azure 资源。

### 练习 2：打开并配置 ASP.NET Core Web 应用程序

#### 任务 1：打开 Web 应用程序

1.  在“**启动**”屏幕上，选择 **Visual Studio Code** 磁贴。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\Starter**，然后选择“**选择文件夹**”。

#### 任务 2：更新应用程序设置

1.  在“Visual Studio Code”窗口的“**资源管理器**”窗格中，展开 **Contoso.Events.Web** 项目。

2.  在“**资源管理器**”窗格中，双击选择“**appsettings.json**”。

3.  在 JSON 对象的第 13 行中，找到 **ConnectionStrings.EventsContextConnectionString** 路径。观察当前为空的值：

<!-- end list -->

    "ConnectionStrings": {
    "EventsContextConnectionString": ""
    },

4.  通过将 **EventsContextConnectionString** 属性的值设置为你之前在此实验室中记录的 **SQL 数据库** **连接字符串**更新其值。

5.  在 JSON 对象的第 9 行中，找到 **CosmosSettings.EndpointUrl** 路径。观察当前为空的值：

<!-- end list -->

    "CosmosSettings": {
    "DatabaseId": "EventsDatabase ",
    "CollectionId": "RegistrationCollection",
    "EndpointUrl": "",
    "AuthorizationKey": ""
    },

6.  通过将 **EndpointUrl** 属性的值设置为你之前在此实验室中记录的 **Azure Cosmos DB 帐户** 的 **终结点 Uri** 更新其值。

7.  在 JSON 对象的第 10 行中，找到 **CosmosSettings.AuthorizationKey** 路径。观察当前为空的值：

<!-- end list -->

    "CosmosSettings": {
    "DatabaseId": "EventsDatabase ",
    "CollectionId": "RegistrationCollection",
    "EndpointUrl": "",
    "AuthorizationKey": ""
    },

8.  通过将 **AuthorizationKey** 属性的值设置为你之前在此实验室中记录的 **Azure Cosmos DB 帐户的** **密钥** 更新其值。

9.  保存 **appsettings.json** 文件。

10. 在“Visual Studio Code”窗口的“**资源管理器**”窗格中，展开 **Contoso.Events.Worker** 项目。

11. 在“**资源管理器**”窗格中，双击选择“**local.settings.json**”。

12. 在 JSON 对象的第 4 行中，找到 **AzureWebJobsStorage** 路径。观察当前为空的值：

<!-- end list -->

    "AzureWebJobsStorage": "",	

13. 通过将 **AzureWebJobsStorage** 属性的值设置为你之前在此实验室中记录的 **存储帐户** **连接字符串** 更新其值。

14. 在 JSON 对象的第 5 行中，找到 **AzureWebJobsDashboard** 路径。观察当前为空的值：

<!-- end list -->

    "AzureWebJobsDashboard": "",

15. 通过将 **AzureWebJobsDashboard** 属性的值设置为你之前在此实验室中记录的 **存储帐户** **连接字符串** 更新其值。

16. 在 JSON 对象的第 6 行中，找到 **EventsContextConnectionString** 路径。观察当前为空的值：

<!-- end list -->

    "EventsContextConnectionString": "",

17. 通过将 **EventsContextConnectionString** 属性的值设置为你之前在此实验室中记录的 **SQL 数据库** **连接字符串** 来更新其值。

18. 在 JSON 对象的第 7 行中，找到 **CosmosEndpointUrl** 路径。观察当前为空的值：

<!-- end list -->

    "CosmosEndpointUrl": "",

19. 通过将 **CosmosEndpointUrl** 属性的值设置为你之前在此实验室中记录的 **Azure Cosmos DB 帐户** 的 **终结点 Uri** 更新其值。

20. 在 JSON 对象的第 8 行中，找到 **CosmosAuthorizationKey** 路径。观察当前为空的值：

<!-- end list -->

    "CosmosAuthorizationKey": "",

21. 通过将 **CosmosAuthorizationKey** 属性的值设置为你之前在此实验室中记录的 **Azure Cosmos DB 帐户的** **密钥** 更新其值。

22. 保存 **local.settings.json** 文件。

#### 回顾

在本练习中，你配置了 ASP.NET Core Web 应用程序以连接到 Azure 中的资源。

### 练习 3：编写实体框架代码以连接到 Azure SQL 数据库

#### 任务 1：配置数据库初始化逻辑

1.  在“Visual Studio Code”窗口的“资源管理器”窗格中，展开 **Contoso.Events.Data** 项目。

2.  在“资源管理器** **”窗格中，双击选择“**ContextInitializer.cs**”。

3.  找到 **InitializeAsync** 方法：

<!-- end list -->

    public async Task InitializeAsync(EventsContext eventsContext)

4.  在 **InitializeAsync** 方法中，添加以下代码行以确保已创建数据库：

<!-- end list -->

    await eventsContext.Database.EnsureCreatedAsync();

5.  添加以下代码块以创建仅当数据库中没有事件时执行代码的条件 **if** 块：

<!-- end list -->

    if (!await eventsContext.Events.AnyAsync())
    {
    }

6.  在新创建的 **if** 块中，添加以下代码行以创建新的 **事件** 类实例：

<!-- end list -->

    Event eventItem = new Event();

7.  在 **if** 块中，添加以下代码块以设置新的 **事件** 类实例的各种属性：

<!-- end list -->

    eventItem.EventKey = "FY17SepGeneralConference";
    eventItem.StartTime = DateTime.Today;
    eventItem.EndTime = DateTime.Today.AddDays(3d);
    eventItem.Title = "FY17 September Technical Conference";
    eventItem.Description = "Sed in euismod mi.";
    eventItem.RegistrationCount = 1;

8.  在 **if** 块中，添加以下代码行以将新的 **事件** 类实例添加到类型为 **DbSet\<Event\>** 的“**事件**”属性：

<!-- end list -->

    eventsContext.Events.Add(eventItem);

9.  在 **if** 块之外及之后，添加下列代码行以将更改保存到数据库上下文：

<!-- end list -->

    await eventsContext.SaveChangesAsync();

10. 你的 **InitializeAsync** 方法现在应该类似于：

<!-- end list -->

    public async Task InitializeAsync(EventsContext eventsContext)
    {
    await eventsContext.Database.EnsureCreatedAsync();
    
    if (!await eventsContext.Events.AnyAsync())
    {
    Event eventItem = new Event();
    eventItem.EventKey = "FY17SepGeneralConference";
    eventItem.StartTime = DateTime.Today;
    eventItem.EndTime = DateTime.Today.AddDays(3d);
    eventItem.Title = "FY17 September Technical Conference";
    eventItem.Description = "Sed in euismod mi.";
    eventItem.RegistrationCount = 1;
    eventsContext.Events.Add(eventItem);
    }
    
    await eventsContext.SaveChangesAsync();
    }

11. **保存** **ContextInitializer.cs** 文件。

#### 任务 2：更新数据库初始化

1.  在“Visual Studio Code”窗口的“资源管理器”窗格中，展开 **Contoso.Events.Data** 项目。

2.  在“资源管理器** **”窗格中，双击选择“**ContextInitializer.cs**”。

3.  找到 **InitializeAsync** 方法：

<!-- end list -->

    public async Task InitializeAsync(EventsContext eventsContext)

4.  用以下方法实现替换方法：

<!-- end list -->

    public async Task InitializeAsync(EventsContext eventsContext)
    {
    await eventsContext.Database.EnsureCreatedAsync();
    
    if (!await eventsContext.Events.AnyAsync())
    {
    await eventsContext.Events.AddRangeAsync(
    new List<Event>() 
    {
    new Event { EventKey = "GeneralConferenceAlpha", StartTime = DateTime.Today, EndTime = DateTime.Today.AddDays(5d), Title = "First General Conference", Description = "Sed in euismod mi.", RegistrationCount = 15 },
    new Event { EventKey = "GeneralConferenceBravo", StartTime = DateTime.Today.AddDays(10d), EndTime = DateTime.Today.AddDays(15d), Title = "Second General Conference", Description = "Sed in euismod mi.", RegistrationCount = 20 },
    new Event { EventKey = "GeneralConferenceCharlie", StartTime = DateTime.Today.AddDays(20d), EndTime = DateTime.Today.AddDays(25d), Title = "Third General Conference", Description = "Sed in euismod mi.",  RegistrationCount = 5 },
    new Event { EventKey = "GeneralConferenceDelta", StartTime = DateTime.Today.AddDays(30d), EndTime = DateTime.Today.AddDays(35d), Title = "Fourth General Conference", Description = "Sed in euismod mi.", RegistrationCount = 25 },
    new Event { EventKey = "GeneralConferenceEcho", StartTime = DateTime.Today.AddDays(40d), EndTime = DateTime.Today.AddDays(45d), Title = "Fifth General Conference", Description = "Sed in euismod mi.", RegistrationCount = 10 },
    new Event { EventKey = "GeneralConferenceFoxtrot", StartTime = DateTime.Today.AddDays(50d), EndTime = DateTime.Today.AddDays(55d), Title = "Sixth General Conference", Description = "Sed in euismod mi.", RegistrationCount = 0 }
    }
    );
    
    await eventsContext.SaveChangesAsync();
    }
    }

5.  **保存** **ContextInitializer.cs** 文件。

#### 任务 3：在 ASP.NET MVC 控制器中编写实体框架查询

1.  在“Visual Studio Code”窗口的“资源管理器** **”窗格中，展开 **Contoso.Events.Web** 项目。

2.  在“资源管理器”窗格中，展开 **Controllers** 文件夹。

3.  在“资源管理器** **”窗格中，双击选择“**HomeController.cs**”。

4.  找到 **Index** 方法：

<!-- end list -->

    public IActionResult Index([FromServices] EventsContext eventsContext, [FromServices] IOptions<ApplicationSettings> appSettings)

5.  在 **Index** 方法中，找到下列代码行：

<!-- end list -->

    var upcomingEvents = Enumerable.Empty<Event>();

6.  用以下代码块替换该代码行以查询 **事件** 表格，按“**StartTime**”属性排序结果，然后根据应用程序设置检索（获取）结果的子集：

<!-- end list -->

    var upcomingEvents = eventsContext.Events
    .Where(e => e.StartTime >= DateTime.Today)
    .OrderBy(e => e.StartTime)
    .Take(appSettings.Value.LatestEventCount);

7.  **保存** **HomeController.cs** 文件。

8.  在“资源管理器** **”窗格中，双击选择“**HomeController.cs**”。

9.  找到 **Index** 方法：

<!-- end list -->

    public IActionResult Index([FromServices] EventsContext eventsContext, [FromServices] IOptions<ApplicationSettings> appSettings, int? page)

10. 在 **Index** 方法中，找到下列代码行：

<!-- end list -->

    var pagedEvents = Enumerable.Empty<Event>();

11. 用以下代码块替换该代码行以查询 **事件** 表格，然后使用 **Skip** 和 **Take** 方法根据当前页码创建结果页面：

<!-- end list -->

    int currentPage = page ?? 1;
    int totalRows = eventsContext.Events.Count();
    int pageSize = appSettings.Value.GridPageSize;
    var pagedEvents = eventsContext.Events
    .OrderByDescending(e => e.StartTime)
    .Skip(pageSize * (currentPage - 1))
    .Take(pageSize);

12. 在 **Index** 方法中，找到下列代码块：

<!-- end list -->

    EventsGridViewModel viewModel = new EventsGridViewModel
    {
    CurrentPage = 0,
    PageSize = 0,
    TotalRows = 0,
    Events = pagedEvents
    };	

13. 用以下代码块替换该代码块以设置 **EventsGridViewModel** 类实例的各种属性：

<!-- end list -->

    EventsGridViewModel viewModel = new EventsGridViewModel
    {
    CurrentPage = currentPage,
    PageSize = pageSize,
    TotalRows = totalRows,
    Events = pagedEvents
    };

14. 找到 **Detail** 方法：

<!-- end list -->

    public IActionResult Detail([FromServices] EventsContext eventsContext, string key)

15. 在 **Detail** 方法中，找到以下代码行：

<!-- end list -->

    var matchedEvent = default(Event);

16. 用以下代码块替换该代码行以查询 **事件** 表格，找到与 **EventKey** 属性匹配的单个记录：

<!-- end list -->

    var matchedEvent = eventsContext.Events
    .SingleOrDefault(e => e.EventKey == key);

17. **保存** **EventsController.cs** 文件。

#### 回顾

在本练习中，你编写了 C\# 代码以使用实体框架连接到 Azure SQL 数据库。

### 练习 4：编写 Cosmos DB 客户端库以连接到 Azure Cosmos DB

#### 任务 1：在 Azure Functions 项目中检索注册者名称

1.  在“Visual Studio Code”窗口的“资源管理器”窗格中，展开 **Contoso.Events.Worker** 项目，然后双击选择 **ProcessDocuments.cs** 文件。

2.  在 **ProcessDocuments.cs** 文件的代码编辑器选项卡中，找到 **ProcessDocuments** 类：

<!-- end list -->

    public static class ProcessDocuments

3.  在 **ProcessDocuments** 类中，在第 19 行添加一行新代码以创建一个新的 **RegistrationContext** 类静态实例。

<!-- end list -->

    private static RegistrationContext _registrationsContext = _connection.GetCosmosContext();

4.  找到 **ProcessHttpRequestMessage** 方法：

<!-- end list -->

    private static async Task<List<string>> ProcessHttpRequestMessage(string eventKey)

5.  在 **ProcessHttpRequestMessage** 方法中，在第 40 行添加一行新代码以使用 **RegistrationContext** 类的 **ConfigureConnectionAsync** 方法配置到 Azure Cosmos DB 的连接：

<!-- end list -->

    await _registrationsContext.ConfigureConnectionAsync();

6.  找到存储 **注册者** 变量中空字符串值集合的第 41 行的代码行：

<!-- end list -->

    List<string> registrants = new List<string>();

7.  用调用 **RegistrationContext** 类的 **GetRegistrantsForEvent** 方法的新代码行替换第 41 行的代码行：

<!-- end list -->

    List<string> registrants = await _registrationsContext.GetRegistrantsForEvent(eventKey);

8.  保存 **ProcessDocuments.cs** 文件。

#### 任务 2：实现 RegistrationContext 类

1.  在“Visual Studio Code”窗口的“资源管理器** **”窗格中，展开 **Contoso.Events.Data** 项目，然后双击选择 **RegistrationContext.cs** 文件。

2.  在 **RegistrationContext.cs** 文件的代码编辑器选项卡中，找到 **RegistrationContext** 类：

<!-- end list -->

    public class RegistrationContext

3.  在 **RegistrationContext** 类中，添加一行新代码以创建一个类型为 **数据库** 的新属性：

<!-- end list -->

    protected Database Database { get; set; }

4.  在 **RegistrationContext** 类中，添加一行新代码以创建一个类型为 **DocumentCollection** 的新属性：

<!-- end list -->

    protected DocumentCollection Collection { get; set; }

5.  在 **RegistrationContext** 类中，添加一行新代码以创建一个类型为 **DocumentClient** 的新属性：

<!-- end list -->

    protected DocumentClient Client { get; set; }

6.  在 **RegistrationContext** 类中，找到现有的 **RegistrationContext** 构造函数：

<!-- end list -->

    public RegistrationContext(IOptions<CosmosSettings> cosmosSettings)
    {
    CosmosSettings = cosmosSettings.Value;
    }

7.  在构造函数中，添加一行新代码以创建一个新的 **DocumentClient** 实例并将其保存到 *客户端* 属性：

<!-- end list -->

    Client = new DocumentClient(new Uri(CosmosSettings.EndpointUrl), CosmosSettings.AuthorizationKey);

8.  在 **RegistrationContext** 类中，找到 **ConfigureConnectionAsync** 方法并删除该方法中的任何现有代码：

<!-- end list -->

    public async Task ConfigureConnectionAsync()
    {
    
    }

9.  在 **ConfigureConnectionAsync** 方法中，添加一行新代码以创建一个新的 **数据库** 实例并将其保存到 **数据库** 属性：

<!-- end list -->

    Database = await Client.CreateDatabaseIfNotExistsAsync(new Database { Id = CosmosSettings.DatabaseId });

10. 添加一行新代码以创建一个新的 **DocumentCollection** 实例并将其保存到 **集合** 属性：

<!-- end list -->

    Collection = await Client.CreateDocumentCollectionIfNotExistsAsync(Database.SelfLink, new DocumentCollection { Id = CosmosSettings.CollectionId });

11. 在 **RegistrationContext** 类中，找到 **GetRegistrantCountAsync** 方法并删除该方法中的任何现有代码：

<!-- end list -->

    public async Task<int> GetRegistrantCountAsync()
    {
    
    }

12. 在 **GetRegistrantCountAsync** 方法中，添加一行新代码以创建一个新的 **FeedOptions** 类实例并将其 **EnableCrossPartitionQuery** 属性设置为“true”值：

<!-- end list -->

    FeedOptions options = new FeedOptions { EnableCrossPartitionQuery = true };

13. 添加一行新代码以创建一个获取注册者数量并返回整数值集合的查询：

<!-- end list -->

    IDocumentQuery<int> query = Client.CreateDocumentQuery<int>(Collection.SelfLink, "SELECT VALUE COUNT(1) FROM registrants", options).AsDocumentQuery();

14. 添加一个新的代码块以创建一个名为 ***count*** 的整数变量，一个在 **IDocumentQuery\<\>** 类的 **HasMoreResults** 属性上循环访问并返回 ***count*** 变量最终值的 while 循环：

<!-- end list -->

    int count = 0;
    while (query.HasMoreResults)
    {
    
    }
    return count;

15. 在 while 循环中，添加一行代码以调用 **IDocumentQuery\<\>** 类的 **ExecuteNextAsync\<\>** 方法并将其结果存储在名为 ***results*** 的类型为 **FeedResponse\<\>** 的变量中：

<!-- end list -->

    FeedResponse<int> results = await query.ExecuteNextAsync<int>();

16. 在 while 循环中，添加一行代码以通过调用 ***results*** 变量中存储的集合上的 **Sum** LINQ 方法递增 ***count*** 变量：

<!-- end list -->

    count += results.Sum();

17. 在 **RegistrationContext** 类中，找到 **GetRegistrantsForEvent** 方法并删除该方法中的任何现有代码：

<!-- end list -->

    public async Task<List<string>> GetRegistrantsForEvent(string eventKey)
    {
    
    }

18. 在 **GetRegistrantsForEvent** 方法中，添加一行使用 LINQ 的代码以通过使用 ***eventKey*** 参数值获取特定时间的注册者并使用 **GeneralRegistration** 类对这些注册者进行反序列化：

<!-- end list -->

    IDocumentQuery<GeneralRegistration> query = Client.CreateDocumentQuery<GeneralRegistration>(Collection.SelfLink).Where(r => r.EventKey == eventKey).AsDocumentQuery();

19. 添加一个新的代码块以创建一个名为 ***registrants*** 的 **List\<\>** 变量，一个在 **IDocumentQuery\<\>** 类的 **HasMoreResults** 属性上循环访问并返回 ***registrants*** 变量最终值的 while 循环：

<!-- end list -->

    List<string> registrants = new List<string>();
    while (query.HasMoreResults)
    {
    
    }
    return registrants;

20. 在 while 循环中，添加一行代码以调用 **IDocumentQuery\<\>** 类的 **ExecuteNextAsync\<\>** 方法并将其结果存储在名为 ***results*** 的类型为 **FeedResponse\<\>** 的变量中：

<!-- end list -->

    FeedResponse<GeneralRegistration> results = await query.ExecuteNextAsync<GeneralRegistration>();

21. 在 while 循环中，添加一行调用 **Select** LINQ 方法的代码以将 **GeneralRegistration** 类的两个属性投射为单个字符串并将得到的集合存储在名为 ***resultNames*** 的类型为 **IEnumerable\<\>** 的变量中：

<!-- end list -->

    IEnumerable<string> resultNames = results.Select(r => $"{r.FirstName} {r.LastName}");

22. 在 while 循环中，添加另一行代码以通过使用 **List\<\>** 类的 **AddRange** 方法将 **注册者** 集合及值追加到 **resultNames** 集合中。

<!-- end list -->

    registrants.AddRange(resultNames);

23. 在 **RegistrationContext** 类中，找到 **UploadEventRegistrationAsync** 方法并删除该方法中的任何现有代码：

<!-- end list -->

    public async Task<string> UploadEventRegistrationAsync(dynamic registration)
    {
    
    }

24. 在 **UploadEventRegistrationAsync** 方法中，添加一行代码以调用类型 **DocumentClient** 的 **客户端** 属性的 **CreateDocumentAsync** 方法并将结果保存为名为 ***response*** 的类型为 **ResourceResponse\<Document\>** 的变量。此方法会将文档上传至 Azure Cosmos DB：

<!-- end list -->

    ResourceResponse<Document> response = await Client.CreateDocumentAsync(Collection.SelfLink, registration);

25. 添加另一行代码以使用点标记访问 ***response*** 变量的 **资源** 属性（**文档**）类型和 **文档** 实例的 **Id** 属性。返回字符串 **Id** 值作为当前方法的结果：

<!-- end list -->

    return response.Resource.Id;

26. 保存 **RegistrationContext.cs** 文件。

#### 回顾

在本练习中，你编写了在 Azure Cosmos DB 中访问和查询文档所需的 C\# 代码。

### 练习 5：编写 Azure SDK 代码以连接到 Azure 存储

#### 任务 1：为 Azure Functions 实现 blob 触发器和输出

1.  在“Visual Studio Code”窗口的“资源管理器** **”窗格中，展开 **Contoso.Events.Worker** 项目，然后双击选择 **ProcessDocuments.cs** 文件。

2.  在 **ProcessDocuments.cs** 文件的代码编辑器选项卡中，找到 **ProcessDocuments** 类：

<!-- end list -->

    public static class ProcessDocuments

3.  在 **ProcessDocuments** 类中，找到 **Run** 方法：

<!-- end list -->

    public static async Task Run(Stream input, string name, Stream output, TraceWriter log)

4.  通过向指定匹配 **signinsheets-pending** 容器中任意 blob 的 *input* 参数添加一个 *BlobTrigger* 参数属性更新 **Run** 方法的方法签名：

<!-- end list -->

    public static async Task Run([BlobTrigger("signinsheets-pending/{name}")] Stream input, string name, Stream output, TraceWriter log)

5.  通过向指定在 **signinsheets** 容器中创建与触发 Function 执行的 blob 名称相同的新 blob 的 *output* 参数中添加一个 *Blob* 参数属性以更新 **Run** 方法的方法签名：

<!-- end list -->

    public static async Task Run([BlobTrigger("signinsheets-pending/{name}")] Stream input, string name, [Blob("signinsheets/{name}", FileAccess.Write)] Stream output, TraceWriter log)

6.  在 **Run** 方法中，在第 23 行添加一行新代码以通过从 blob 名称去除文件扩展名以获取 **事件键**：

<!-- end list -->

    string eventKey = Path.GetFileNameWithoutExtension(name);

7.  在第 24 行添加一行新代码以通过使用 **ProcessStorageMessage** 方法调用的 **Stream** 结果以创建一个 **using** 块：

<!-- end list -->

    using (MemoryStream stream = await ProcessStorageMessage(eventKey))
    {
    
    }

8.  在 **using** 块中，添加一行新代码以通过调用流的 **ToArray** 方法创建一个类型为 **byte\[\]** 的新变量：

<!-- end list -->

    byte[] byteArray = stream.ToArray();

9.  在 **using** 块中，添加另一行代码以调用将各种相关元数据传递至 *byteArray* 变量的 *output* 变量 **WriteAsync** 方法。

<!-- end list -->

    await output.WriteAsync(byteArray, 0, byteArray.Length);

10. 保存 **ProcessDocuments.cs** 文件。

#### 任务 2：BlobContext 类中实现 blob 上传

1.  在“Visual Studio Code”窗口的“资源管理器”窗格中，展开 **Contoso.Events.Data** 项目，然后双击选择 **BlobContext.cs** 文件。

2.  在 **BlobContext.cs** 文件的代码编辑器选项卡中，找到 **BlobContext** 类：

<!-- end list -->

    public class BlobContext

3.  在 **BlobContext** 类中，找到 **UploadBlobAsync** 方法并删除该方法中的任何现有代码：

<!-- end list -->

    public async Task<ICloudBlob> UploadBlobAsync(string blobName, Stream stream)
    {
    
    }

4.  在 **UploadBlobAsync** 方法中，添加一行新代码以创建一个新的 **CloudStorageAccount** 类实例：

<!-- end list -->

    CloudStorageAccount account = CloudStorageAccount.Parse(StorageSettings.ConnectionString);

5.  添加一行新代码以通过使用 **CloudStorageAccount** 类的 **CreateCloudBlobClient** 代码创建一个新的 **CloudBlobClient** 类实例：

<!-- end list -->

    CloudBlobClient blobClient = account.CreateCloudBlobClient();

6.  添加一行新代码以通过使用 **CloudBlobClient** 类的 **GetContainerReference** 方法获取新的或现有容器的引用：

<!-- end list -->

    CloudBlobContainer container = blobClient.GetContainerReference($"{StorageSettings.ContainerName}-pending");

7.  添加一行新代码以调用将在容器不存在时创建容器的 **CloudBlobContainer** 类的 **CreateIfNotExistsAsync** 方法：

<!-- end list -->

    await container.CreateIfNotExistsAsync();

8.  添加一行新代码以通过使用特定 blob 名称获取新的或现有容器的引用：

<!-- end list -->

    ICloudBlob blob = container.GetBlockBlobReference(blobName);

9.  添加一行新代码以获取 ***stream*** 参数并将流还原为原始值：

<!-- end list -->

    stream.Seek(0, SeekOrigin.Begin);

10. 添加一行新代码以将 ***stream*** 参数的内容上传到引用的 blob：

<!-- end list -->

    await blob.UploadFromStreamAsync(stream);

11. 添加一行新代码以将上传的 blob 作为方法结果返回：

<!-- end list -->

    return new DownloadPayload { Stream = stream, ContentType = blob.Properties.ContentType }; 

12. **保存** **BlobContext.cs** 文件。

#### 回顾

在本练习中，你编写了 C\# 代码以在 Azure Function 中操纵 Azure 存储 Blob。

### 练习 6：清理订阅 

#### 任务 1：打开 Azure Cloud Shell

1.  在门户顶部，选择 **Cloud Shell** 图标打开一个新的 Shell 实例。

2.  在门户底部的 **Cloud Shell** 命令提示符中，输入以下命令，然后按 Enter 键列出订阅中的所有资源组：

<!-- end list -->

    az group list

3.  在提示符中，输入以下命令，然后按 Enter 键查看删除资源组的可能命令列表：

<!-- end list -->

    az group delete --help

#### 任务 2：删除资源组

1.  在提示符中，输入以下命令，然后按 Enter 键删除 **PolyglotData** 资源组：

<!-- end list -->

    az group delete --name PolyglotData --no-wait --yes

2.  关闭门户底部的“**Cloud Shell**”窗格。

#### 任务 3：关闭活动应用程序

1.  关闭当前正在运行的 **Microsoft Edge** 应用程序。

2.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你通过移除本实验室中使用过的 **资源组** 来清理订阅。
