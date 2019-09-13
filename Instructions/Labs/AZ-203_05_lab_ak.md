---
lab:
    title: '实验室：监视部署到 Azure 的服务'
    type: '答案'
    module: '模块 5：监视、排除故障并优化 Azure 解决方案'
---

# 实验室：监视部署到 Azure 的服务
# 学生实验室答案

## Microsoft Azure 用户界面

鉴于 Microsoft 云工具的动态特性，Azure 用户界面 (UI) 在此培训内容开发后可能会发生更改。这些更改可能会导致实验室说明和步骤不匹配。

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
    
      - Windows PowerShell

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

### 练习 1：创建和配置 Azure 资源

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

2.  在打开的浏览器窗口中，导航到 [**Azure 门户**](https://portal.azure.com) (portal.azure.com)。

3.  在登录页面，输入 Microsoft 帐户的 **电子邮件地址**。

4.  选择“**下一步**”。

5.  输入 Microsoft 帐户的**密码**。

6.  选择“**登录**”。

> **注**：如果这是你第一次登录 **Azure 门户**，则会显示提供门户教程的对话框。选择“**开始使用**”以跳过教程并开始使用门户。

#### 任务 2：创建 Application Insights 资源

1.  在门户的左侧导航窗格，单击“**+ 创建资源**”。

2.  在“**新建**”边栏选项卡顶部，找到“**搜索市场**”字段。

3.  在搜索字段中，输入 **Insights**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**Application Insights**”结果。

5.  在“**Application Insights**”边栏选项卡中，选择“**创建**”。

6.  在第二个“**Application Insights**”边栏选项卡中，执行以下操作：
    
    1.  在“**名称**”字段中，输入 **instrm\[*your name in lowercase*\]**。
    
    2.  在“**应用程序类型**”列表中，选择“**ASP.NET 应用程序**”。
    
    3.  将“**订阅**”字段保留设置为默认值。
    
    4.  在“**资源组**”部分，选择“**新建**”，然后输入 **MonitoredAssets**。
    
    5.  在“**位置**”拉列表中，选择“**美国东部**”。
    
    6.  选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

8.  在门户左侧的导航窗格中，选择“**资源组**”。

9.  在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

10. 在“**MonitoredAssets**”边栏选项卡中，选择你之前在本实验室中创建的 **instrm\*** Application Insights。

11. 在“**Application Insights**”边栏选项卡中，在边栏选项卡左侧的“**配置**”类别选择“**属性**”链接。

12. 在“**属性**”部分，观察“**检测密钥**”字段的值。客户端应用程序使用此密钥连接到 Application Insights。

#### 任务 3：创建 API 应用资源

1.  在门户的左侧导航窗格，单击“**+ 创建资源**”。

2.  在“**新建**”边栏选项卡顶部，找到“**搜索市场**”字段。

3.  在搜索字段中，输入 **API**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**API 应用**”结果。

5.  在“**API 应用**”边栏选项卡中，选择“**创建**”。

6.  在第二个“**API 应用**”边栏选项卡中，执行以下操作：
    
    1.  在“**应用名称**”字段中，输入 **smpapi\[*your name in lowercase*\]**。
    
    2.  将“**订阅**”字段保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后选择“**MonitoredAssets**”。
    
    4.  选择“**应用服务计划/位置**”字段。

7.  在“**应用服务计划**”边栏选项卡中，选择“**新建**”。

8.  在“**新建应用服务计划**”边栏选项卡中，执行以下操作：
    
    5.  在“**应用服务计划**”字段中，输入 **MonitoredPlan**。
    
    6.  在“**位置**”列表中，选择“**美国东部**”位置。
    
    7.  将“**定价层**”字段设置为值 **(S1)**。
    
    8.  选择“**确定**”。

9.  回到“**API 应用**”边栏选项卡，选择“**Application Insights**”按钮。

10. 在“**Application Insights**”边栏选项卡中，执行以下操作：
    
    9.  在“**Application Insights 站点扩展**”部分，选择“**启用**”。
    
    10. 在“**链接到 Application Insights 资源**”部分，选择“**选择现有资源**”，然后选择之前在本实验室中创建的 **instrm\*** Application Insights 帐户。
    
    11. 在“**检测应用程序**”部分，选择“ **NET Core**”选项卡，然后选择“**推荐**”。
    
    12. 选择“**应用**”。

11. 返回“**API 应用**”边栏选项卡，选择“**创建**”。

12. 等待创建任务完成后，再继续本实验室。

13. 在门户左侧的导航窗格中，选择“**资源组**”。

14. 在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

15. 在“**MonitoredAssets**”边栏选项卡中，选择你之前在本实验室中创建的 **smpapi\*** API 应用。

16. 在“**应用服务**”边栏选项卡中，在边栏选项卡左侧的“**设置**”类别选择“**应用程序设置**”链接。

17. 在“**应用程序设置**”部分，向下滚动，直到找到 API 的“**应用程序设置**”列表。

18. 选择“**显示值**”以查看与你的 API 相关的机密。

19. 观察与 **APPINSIGHTS\_INSTRUMENTATIONKEY** 密钥相对应的值。构建 API 应用资源时会自动设置此值。

20. 在“**应用服务**”边栏选项卡中，在边栏选项卡左侧的“**设置**”类别选择“**应用属性**”链接。

21. 在“**属性**”部分，记录“**URL**”字段的值。稍后你将在本实验室中使用此值来对 API 发出请求。

#### 任务 4：配置 API 应用自动缩放选项

1.  在“**应用服务**”边栏选项卡中，在边栏选项卡左侧的“**设置**”类别选择“**横向扩展**”链接。

2.  在“**横向扩展部分**”部分中，执行以下操作：
    
    1.  选择“**启用横向扩展**”。
    
    2.  在“**自动缩放设置名称**”字段中，输入 **ComputeScaler**。
    
    3.  在“**资源组**”列表中，选择“**MonitoredAssets**”。
    
    4.  在“**缩放模式**”部分中，选择“**根据指标缩放**”。
    
    5.  在“**实例限制**”部分的“**最小**”字段，输入 **2**。
    
    6.  在“**实例限制**”部分的“**最大**”字段，输入 **8**。
    
    7.  在“**实例限制**”部分的“**默认值**”字段，输入 **3**。
    
    8.  选择“**+ 添加规则**”。在显示的“**缩放规则**”窗口中，将所有字段保留设置为默认值，然后选择“**添加**”。
    
    9.  在该部分顶部，单击“**保存**”。

3.  等待保存操作完成后再继续本实验室。

#### 回顾

在本练习中，你创建了所有将用于本实验室其余部分的资源。

### 练习 2：构建和部署 ASP.NET Core Web API 应用程序

#### 任务 1：构建 .NET Core Web API 项目

1.  在任务栏上，选择 **Visual Studio Code** 图标。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\05\\Starter\\Api**，然后选择“**选择文件夹**”。

4.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击“**资源管理器**”窗格，然后选择“**在终端中打开**”。

5.  在打开的命令提示符中，输入以下命令并按 Enter 键以在当前目录中创建一个名为 **SimpleApi** 的 .NET Core Web API 应用程序：

dotnet new webapi --output .--name SimpleApi

6.  在命令提示符中，输入以下命令并按 Enter 键以将 **2.6.1** 版本的 **Microsoft.ApplicationInsights.AspNetCore** 程序包从 NuGet 添加到当前项目：

dotnet add package Microsoft.ApplicationInsights.AspNetCore --version 2.6.1

7.  在命令提示符中，输入以下命令并按 Enter 键以构建 .NET Core Web 应用程序：

dotnet build

#### 任务 2：更新应用程序代码以禁用 HTTPS 并使用 Application Insights

1.  在“**Visual Studio Code**”窗口左侧的“**Explorer**”窗格中，双击 **Program.cs** 文件以在编辑器中打开该文件。

2.  在编辑器的 **Program** 类中，在第 **20** 行找到以下代码块：

public static IWebHostBuilder CreateWebHostBuilder(string\[\] args) =\>

WebHost.CreateDefaultBuilder(args)

.UseStartup\<Startup\>();

3.  使用启用项目 **Application Insights** 遥测的以下代码块替换该代码块：

public static IWebHostBuilder CreateWebHostBuilder(string\[\] args) =\>

WebHost.CreateDefaultBuilder(args)

.UseStartup\<Startup\>()

.UseApplicationInsights();

4.  **保存** **Program.cs** 文件。

5.  在“**Visual Studio Code**”窗口左侧的“**Explorer**”窗格中，双击 **Startup.cs** 文件以在编辑器中打开该文件。

6.  在编辑器的 **Program** 类中，在第 **44** 行找到并删除以下代码行：

app.UseHttpsRedirection();

> > **注**：这行代码强制 API 应用使用 HTTPS。对于本实验室而言，这不是必要的。

7.  **保存** **Startup.cs** 文件。

<!-- end list -->

8.  找到屏幕底部的命令提示符。在命令提示符中，输入以下命令并按 Enter 键以构建 .NET Core Web 应用程序。

dotnet build

#### 任务 3：本地测试 API 应用程序

1.  找到屏幕底部的命令提示符。在命令提示符中，输入以下命令并按 Enter 键以执行 .NET Core Web 应用程序。

dotnet run

2.  在任务栏上，选择 **Microsoft Edge** 图标。

3.  在打开的浏览器窗口中，导航到在端口 **5000** 的 **localhost** 托管的测试应用程序的 **/api/values** 相对路径。
    
    **注**：完整的 URL 为 http://localhost:5000/api/values

4.  在同一浏览器窗口中，导航到在端口 **5000** 的 **localhost** 托管的测试应用程序的 **/api/values** 相对路径。
    
    **注**：完整的 URL 为 http://localhost:5000/api/values/7

5.  关闭显示 http://localhost:5000/api/values/7 地址的浏览器窗口。

6.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 任务 4：在 Application Insights 中查看指标

1.  返回显示 **Azure 门户** 的当前打开的浏览器窗口。

2.  在门户左侧，选择“**资源组**”。

3.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

4.  在“**MonitoredAssets**”边栏选项卡中，选择你之前在本实验室中创建的 **instrm\*** Application Insights。

5.  在“**Application Insights**”边栏选项卡中，在位于边栏选项卡中心的磁贴中，观察显示的磁贴。具体来说，观察已发生的 **服务器** **请求** 数量以及平均 **服务器响应时间**。

#### 任务 5：将应用程序部署到 API 应用

1.  在任务栏上，选择 **Visual Studio Code** 图标。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\Starter\\Api**，然后选择“**选择文件夹**”。

4.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击“**Explorer**”窗格，然后选择“**在终端中打开**”。

5.  在打开的命令提示符中，输入以下命令并按 Enter 键以登录 Azure CLI：

az login

6.  在显示的窗口中，执行以下操作：
    
    1.  输入 Microsoft 帐户的 **电子邮件地址**。
    
    2.  选择“**下一步**”。
    
    3.  输入 Microsoft 帐户的 **密码**。
    
    4.  选择“**登录**”。

7.  返回当前打开的“**命令提示符**”应用程序。等待登录过程完成。

8.  在命令提示符下，输入以下命令并按 Enter 键以列出 **MonitoredAssets** 资源组中的所有 **应用**：

az webapp list --resource-group MonitoredAssets

9.  输入以下命令并按 Enter 键以查找具有前缀 **smpapi\*** 的**应用**：

az webapp list --resource-group MonitoredAssets --query "\[?starts\_with(name, 'smpapi')\]"

10. 输入以下命令并按 Enter 键以仅打印具有前缀 **smpapi\*** 的单应用的名称：

az webapp list --resource-group MonitoredAssets --query "\[?starts\_with(name, 'smpapi')\].{Name:name}" --output tsv

11. 输入以下命令并按 Enter 键以将当前目录更改为包含部署文件的 **Allfiles (F):\\Labfiles\\05\\Starter** 目录：

cd F:\\Labfiles\\05\\Starter\\

12. 输入以下命令并按 Enter 键以将 **api.zip** 文件部署到之前在此实验室中创建的 **API 应用**：

az webapp deployment source config-zip --resource-group MonitoredAssets --src api.zip --name \<name-of-your-api-app\>

> > **注**：用你之前在本实验室中创建的 API 应用名称替换 **\<name-of-your-api-app\>** 占位符。你最近在之前步骤中查询了此应用的名称。

13. 等待部署完成后再继续本实验室。

14. 关闭当前正在运行的 **Visual Studio Code** 应用程序。

15. 在门户左侧的导航窗格中，选择“**资源组**”。

16. 在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

17. 在“**ManagedPlatform**”边栏选项卡中，选择你之前在此实验室中创建的 **imgapi\*** API 应用。

18. 在“**应用服务**”边栏选项卡中，选择边栏选项卡顶部的“**浏览**”。

19. 将打开一个新的浏览器窗口或标签页并返回“**404（未找到）**”错误。在浏览器地址栏中，通过在当前 URL 末尾追加后缀 **/api/values** 并按 Enter 键来更新 URL。

> > **注**：例如，如果你的 URL 为 http://smpapistudent.azurewebsites.net，则新的 URL 为 http://smpapistudent.azurewebsites.net/api/values。

20. 观察作为使用 API 结果返回的 JSON 数组。

#### 回顾

在本练习中，你使用 ASP.NET Core 创建了一个 API，并将其配置为将应用程序指标流式传输到 Application Insights。然后，你使用 Application Insights 仪表板查看有关 API 应用以及应用中运行的 API 的性能详细信息。

### 练习 3：使用 .NET Core 构建客户端应用程序

#### 任务 1：构建 .NET Core 控制台项目

1.  在任务栏上，选择 **Visual Studio Code** 图标。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\Starter\\Console**，然后选择“**选择文件夹**”。

4.  在“Visual Studio Code”窗口中，访问上下文菜单或右键单击“**Explorer**”窗格，然后选择“**在终端中打开**”。

5.  在打开的命令提示符中，输入以下命令并按 Enter 键以在当前目录中创建一个名为**SimpleConsole** 的 .NET Core 控制台应用程序：

dotnet new console --output .--name SimpleConsole

6.  在命令提示符中，输入以下命令并按 Enter 键以将 **2.2.29** 版本的 **Microsoft.Net.Http** 程序包从 NuGet 添加到当前项目：

dotnet add package Microsoft.Net.Http --version 2.2.29

7.  在命令提示符中，输入以下命令并按 Enter 键以将 **7.0.2** 版本的 **Polly** 程序包从 NuGet 添加到当前项目：

dotnet add package Polly --version 7.0.2

8.  在命令提示符中，输入以下命令并按 Enter 键以构建 .NET Core Web 应用程序：

dotnet build

#### 任务 2：添加 HTTP 客户端代码

1.  在“**Visual Studio Code**”窗口左侧的“**Explorer**”窗格中，双击 **Program.cs** 文件以在编辑器中打开该文件。

2.  在编辑器中，为 **System.Net.Http** 命名空间添加以下 **using** 块：

using System.Net.Http;

3.  在编辑器中，为 **System.Threading.Tasks** 命名空间添加以下 **using** 块：

using System.Threading.Tasks;

4.  在 **SimpleConsole** 命名空间中，找到第 **7** 行的以下类：

class Program

{

static void Main(string\[\] args)

{

Console.WriteLine("Hello World\!");

}

}

5.  使用以下实现替换整个 **Program** 类：

class Program

{

private const string \_api = "";

private static HttpClient \_client = new HttpClient(){ BaseAddress = new Uri(\_api) };

static void Main(string\[\] args)

{

Run().Wait();

}

static async Task Run()

{

}

}

6.  找到第 **9** 行的 **\_api** 常数：

private const string \_api = "";

7.  通过将变量值设置为之前在此实验室中记录的 API 应用 **URL** 更新 **\_api** 常数：

> > **注**：例如，如果你的 URL 为 http://smpapistudent.azurewebsites.net，新的代码行将为：private const string \_api = "http://smpapistudent.azurewebsites.net"；

8.  在 **Run** 方法中，添加以下代码行以异步调用传入相对路径 **/api/values/**, 的 **HttpClient.GetStringAsync** 方法：

string response = await \_client.GetStringAsync("/api/values/");

9.  在 **Run** 方法中，添加另一行代码以将响应从 **GET** 要求写出到控制台：

Console.WriteLine(response);

10. 你的 **Program.cs** 文件现在应具有以下代码：

using System;

using System.Net.Http;

using System.Threading.Tasks;

namespace SimpleConsole

{

class Program

{

private const string \_api = "http://\<your-api-name\>.azurewebsites.net ";

private static HttpClient \_client = new HttpClient(){ BaseAddress = new Uri(\_api) };

static void Main(string\[\] args)

{

Run().Wait();

}

static async Task Run()

{

string response = await \_client.GetStringAsync("/api/values/");

Console.WriteLine(response);

}

}

}

11. **保存** **Program.cs** 文件。

#### 任务 3：本地测试控制台应用程序

1.  在屏幕底部的命令提示符中，输入以下命令并按 Enter 键以执行 .NET Core Web 应用程序。

dotnet run

2.  观察应用程序在 Azure 中成功调用 API 应用并返回之前在本实验室中观察到的相同 JSON 数组。结果应类似于以下 JSON 内容：

\["value1","value2"\]

3.  返回显示 **Azure 门户**的当前打开的浏览器窗口。

4.  在门户左侧，选择“**资源组**”。

5.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

6.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在此实验室中创建的 **imgapi\*** API 应用。

7.  在“**应用服务**”边栏选项卡中，选择边栏选项卡顶部的“**停止**”以停止 API 应用执行。

8.  在“**停止 Web 应用**”确认对话框中，选择“**是**”。

9.  在任务栏上，选择 **Visual Studio Code** 图标。

10. 在“**文件**”菜单上，选择“**打开文件夹**”。

11. 在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\Starter\\Console**，然后选择“**选择文件夹**”。

12. 在“Visual Studio Code”窗口中，访问上下文菜单或右键单击“**Explorer**”窗格，然后选择“**在终端中打开**”。

13. 在打开的命令提示符中，输入以下命令并按 Enter 键以执行 .NET Core Web 应用程序。

dotnet run

14. 观察应用程序执行失败并显示一条类似于以下异常消息的 **HttpRequestException** 消息：

System.Net.Http.HttpRequestException: Response status code does not indicate

success: 403 (Site Disabled).

at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()

at System.Net.Http.HttpClient.GetStringAsyncCore(Task\`1 getTask)

at SimpleConsole.Program.Run() in F:\\Labfiles\\Starter\\Console\\Program.cs:line 20

> > **注**：发生此异常是因为 API 应用不再可用。

#### 任务 4：使用 Polly 添加重试逻辑

1.  在“**Visual Studio Code**”窗口左侧的“**Explorer**”窗格中，双击 **PollyHandler.cs** 文件以在编辑器中打开该文件。

2.  在 **PollyHandler** 类中，观察第 **13-24** 行。这些代码行使用 **NET Foundation** 的 **Polly** 库创建每五分钟重试一次失败的 HTTP 请求的重试策略。

3.  在“**Visual Studio Code**”窗口左侧的“**Explorer**”窗格中，双击 **Program.cs** 文件以在编辑器中打开该文件。

4.  找到第 **10** 行的 **\_client** 常数：

private static HttpClient \_client = new HttpClient(){ BaseAddress = new Uri(\_api) };

5.  将 **HttpClient** 构造函数更新为使用新的 **PollyHandler** 类实例来更新 **\_client** 常数：

private static HttpClient \_client = new HttpClient(new PollyHandler()){ BaseAddress = new Uri(\_api) };

6.  **保存** **Program.cs** 文件。

#### 任务 5：验证重试逻辑

1.  在屏幕底部的命令提示符中，输入以下命令并按 Enter 键以执行 .NET Core Web 应用程序。

dotnet run

2.  观察 HTTP 请求执行继续失败并每五秒重试一次。应用程序失败时，你将在控制台看到以下消息：

尝试失败

3.  让控制台应用程序保持运行。它会无限尝试访问 API 应用程序，直到成功为止。

4.  返回显示 **Azure 门户**的当前打开的浏览器窗口。

5.  在门户左侧，选择“**资源组**”。

6.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

7.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在此实验室中创建的 **imgapi\*** API 应用。

8.  在“**应用服务**”边栏选项卡中，选择边栏选项卡顶部的“**开始**”以继续 API 应用。

9.  在“**停止 Web 应用**”确认对话框中，选择“**是**”。

10. 返回当前正在运行的 **Visual Studio Code** 应用程序。

11. 观察应用程序最终在 Azure 中成功调用 API 应用并返回之前在本实验室中观察到的相同 JSON 数组。结果应与以下 JSON 内容类似：

\["value1","value2"\]

12. 关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你使用条件重试逻辑创建了一个控制台应用程序来访问 API。无论 API 应用是否可用，应用程序都会继续工作。

### 练习 4：加载测试 API 应用

#### 任务 1：在 API 应用上运行性能测试

1.  返回显示 **Azure 门户**的当前打开的浏览器窗口。

2.  在门户左侧，选择“**资源组**”。

3.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **MonitoredAssets** 资源组。

4.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在此实验室中创建的 **imgapi\*** API 应用。

<!-- end list -->

4.  在“**应用服务**”边栏选项卡中，在边栏选项卡左侧的“**开发工具**”类别选择“**性能测试**”链接。

<!-- end list -->

5.  在“**性能测试**”部分顶部，选择“**新建**”。

6.  在“**新建性能测试**”边栏选项卡中，执行以下操作：
    
    1.  在“**名称**”字段中，输入 **LoadTest**。
    
    2.  在“**生成负载位置**”列表中，选择“**美国东部（Web 应用位置）**”。
    
    3.  在“**用户负载**”字段，输入 **1000**。
    
    4.  在“**持续时间**”字段，输入 **10**。
    
    5.  选择“**配置测试使用**”。

7.  在“**配置测试使用**”边栏选项卡中，执行以下操作：
    
    6.  在“**测试类型**”列表中，选择“**手动测试**”。
    
    7.  在 **URL** 字段中，通过在当前 URL 末尾追加后缀 **/api/values** 来更新 URL。

> > **注**：例如，如果你的 URL 为 http://smpapistudent.azurewebsites.net，则新的 URL 为 http://smpapistudent.azurewebsites.net/api/values。

8.  选择“**完成**”。

<!-- end list -->

8.  返回“**新建性能测试**”边栏选项卡，选择“**运行测试**”。

9.  返回“**性能测试**”部分，在“**最近运行**”列表中，选择“**LoadTest**”。

10. 在“**LoadTest**”边栏选项卡中，等待测试开始再继续此实验室。

> > **注**：大部分加载测试需要大约 10 到 15 分钟来收集资源并启动。你可以在此边栏选项卡等待，因为负载测试启动时，其会自动更新。

11. 等待负载测试完成再继续本实验室。观察实时图表随着 API 应用使用量增加更新。

> > **注**：负载测试将需要在本实验室之前步骤指定的 10 分钟时间。

#### 任务 2：在性能测试后使用 Azure Monitor 指标

1.  在 Azure 门户的左侧导航窗格，单击“**所有服务**”。

2.  在“**所有服务**”边栏选项卡中，选择“**监视器**”。

3.  在“**监视器**”边栏选项卡中，在边栏选项卡左侧，选择“**指标**”。

4.  在“**指标**”部分，执行以下操作：
    
    1.  在“**资源**”部分，选择“**选择资源**”。
    
    2.  在显示的“**选择资源**”窗口，在“**资源组**”列表中，选择“**MonitoredAssets**”。然后，在“**资源**”列表中，选择 **instrm\*** Application Insights 帐户选项。最后，选择“**应用**”关闭窗口并确认选择。
    
    3.  在“**指标命名空间**”列表的“**标准**”类别中，选择“**标准指标**”。
    
    4.  在“**指标**”列表的“**性能计数器**”类别中，选择“**处理 CPU**”。
    
    5.  在“**聚合**”列表中，选择“**平均**”。
    
    6.  在该部分顶部，选择“**过去 24 小时（自动）**”。在显示窗口的“**时间范围**”类别中，选择“**过去 30 分钟**”，然后选择“**应用**”以保存选择。
    
    7.  在该部分顶部，单击“**折线图**”。在显示的菜单中，选择“**分区图**”。

5.  观察新创建的图表。

6.  在该部分顶部，单击“**添加指标**”。

7.  在里面“**指标**部分”，使用列表中的新指标项目执行以下操作：
    
    8.  在“**指标命名空间**”列表的“**标准**”类别中，选择“**基于日志的指标**”。
    
    9.  在“**指标**”列表的“**服务器**”类别中，选择“**服务器响应时间**”。
    
    10. 在“**聚合**”列表中，选择“**平均**”。

8.  观察更新后的图表。观察图表中显示的信息。你可以随着应用程序负载增加，观察服务器响应时间与 CPU 时间的关系。

#### 回顾

在本练习中，你使用 Azure 中的可用工具对 API 应用程序执行了性能（负载）测试。执行负载测试后，你可以使用 Azure Monitor 界面中的指标来衡量 API 应用的行为。

### 练习 5：清理订阅 

#### 任务 1：打开 Cloud Shell

1.  在 Azure 门户的顶部，选择 **Cloud Shell** 图标打开一个新的 Shell 实例。

2.  在门户底部的 **Cloud Shell** 命令提示符下，输入以下命令并按 Enter 键以列出订阅中的所有资源组。

az group list

3.  输入以下命令，然后按 Enter 键查看删除资源组的可能命令列表：

az group delete --help

#### 任务 2：删除资源组

1.  输入以下命令，然后按 Enter 键删除 **MonitoredAssets** 资源组：

az group delete --name MonitoredAssets --no-wait --yes

2.  关闭门户底部的“**Cloud Shell**”窗格。

#### 任务 3：关闭活动应用程序

1.  关闭当前正在运行的 **Microsoft Edge** 应用程序。

2.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你通过移除本实验室中使用过的 **资源组** 来清理订阅。
