---
lab:
    title: '实验室：在 Azure 平台即服务 (PaaS) 产品上构建 Web 应用程序'
    type: '答案'
    module: '模块 2：开发 Azure 平台即服务 (PaaS) 计算解决方案'
---

# 实验室：在 Azure 平台即服务 (PaaS) 产品上构建 Web 应用程序
# 学生实验室答案

## Microsoft Azure 用户界面

鉴于 Microsoft 云工具的动态特性，Azure 用户界面 (UI) 在此培训内容开发后可能会发生更改。这些更改可能会导致实验室说明和步骤不匹配。

一旦 Microsoft 世界各地的学习团队通过社区注意到必要更改，将会立即更新此培训课程。但由于云更新频繁，你可能会在此培训内容更新前遇到 UI 更改。**如果发生这种情况，请根据需要适更改并在实验室中完成这些更改。**

## 说明

### 开始前

#### 登录实验室虚拟机

使用以下凭据登录到 **Windows 10** 虚拟机：
    
-   **用户名**： Admin
    
-   **密码**： Pa55w.rd

> **注**： 讲师将为你提供实验室虚拟机登录说明。

#### 查看已安装的应用

观察位于 **Windows 10** 桌面底部的任务栏。任务栏包含将在本实验室中使用的应用程序图标：
    
-   Microsoft Edge

-   文件资源管理器

-   Windows PowerShell

-   Visual Studio Code

#### 下载实验室文件

1.  在任务栏上，选择 **Windows PowerShell** 图标。

1.  在 PowerShell 命令提示符中，将当前工作目录更改为 **Allfiles (F):\\** 路径：

```
cd F:
```

1.  在命令提示符中，输入以下命令并按 Enter 键以将 GitHub 上托管的 **microsoftlearning/AZ-203-DevelopingSolutionsforMicrosoftAzure** 项目克隆到 **Allfiles (F):\\** 路径：

```
git clone --depth 1 --no-checkout https://github.com/microsoftlearning/AZ-203-DevelopingSolutionsForMicrosoftAzure .
```

1.  在命令提示符中，输入以下命令并按 **Enter** 键以签出完成 **AZ-203T02** 实验室所必需的实验室文件：

```
git checkout master -- Allfiles/*
```

1.  关闭当前正在运行的 **Windows PowerShell** 命令提示应用程序。

### 练习 1：使用 Azure 存储和 API 应用程序构建后端 API

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

1.  在打开的浏览器窗口中，导航到 [**Azure 门户**](https://portal.azure.com) (portal.azure.com)。

1.  在登录页面，输入 Microsoft 帐户的 **电子邮件地址**。

1.  选择 **下一步**。

1.  输入 Microsoft 帐户的 **密码**。

1.  选择 **登录**。

    > **注**： 如果这是你第一次登录 Azure 门户，则会显示一个对话框，提供门户教程。选择 **开始使用** 以跳过教程并开始使用门户。

#### 任务 2：创建 Azure 存储帐户

1.  在 Azure 门户的左侧导航窗格，单击 **所有服务**。

1.  在 **所有服务** 边栏选项卡中，选择 **存储帐户**。

1.  在 **存储帐户** 边栏选项卡中，查看存储实例列表。

1.  在 **存储帐户** 边栏选项卡顶部，选择 **添加**。

1.  在 **创建存储帐户** 边栏选项卡中，观察边栏选项卡顶部的选项卡，如“基本”、“标记”和“查看 + 创建”。

    > **注**： 每个选项卡代表工作流中创建新 **存储帐户** 的一个步骤。你可以随时选择 **查看 + 创建** 跳过剩余标签。

1.  选择 **基本** 选项卡，然后在选项卡区域内执行以下操作：
    
    1.  将 **订阅** 字段保留设置为默认值。
    
    1.  在 **资源组** 部分，选择 **新建**，输入 **ManagedPlatform**，然后选择 **确定**。
    
    1.  在 **存储帐户** **名称** 字段，输入 **imgstor\[*your name in lowercase*\]**。
    
    1.  在 **位置** 列表中，选择 **（美国）美国东部** 区域。
    
    1.  在 **性能** 部分，选择 **标准**。
    
    1.  在 **帐户类型** 列表中，选择 **StorageV2（通用 v2）**。
    
    1.  在 **复制** 列表中，选择 **本地冗余存储 (LRS)**。
    
    1.  在 **访问层（默认）** 部分，确保 **热** 已选中。
    
    1.  选择 **查看 + 创建**。

1.  在 **查看 + 创建** 选项卡中，查看在之前步骤中指定的选项。

1.  选择 **创建** 以使用指定的配置创建存储帐户。

1.  在 **部署** 边栏选项卡中，等待创建任务完成后再继续本实验室。

1. 点击 **部署** 边栏选项卡中的 **前往资源** 按钮，以转到新创建的存储帐户。

1. 在 **存储帐户** 边栏选项卡中，在边栏选项卡左侧，找到 **设置** 部分并选择 **访问密钥**。

1. 在 **访问密钥** 边栏选项卡中，选择任意一个密钥并记录 **连接字符串**字段中的任意一个值。你将稍后在本实验室中使用此值。

    > **注**： 选择哪个连接字符串无关紧要。它们可以互换。

#### 任务 3：上传示例 blob

1.  在 Azure 门户左侧导航窗格中，选择 **资源组**。

1.  在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgstor\** 存储帐户。

1.  在 **存储帐户** 边栏选项卡中，在边栏选项卡左侧的 **Blob 服务** 部分，选择 **容器** 链接。

1.  在 **容器** 部分，选择 **+ 容器**。

1.  在 **新建容器** 窗口中，执行以下操作：
    
    1.  在 **名称** 字段中，输入 **images**。
    
    1.  在 **公共访问级别** 列表中，选择 **Blob（仅限 blob 匿名读取访问）**。
    
    1.  选择 **确定**。

1.  在 **容器** 部分，再次选择 **+ 容器**。

1.  在 **新建容器** 窗口中，执行以下操作：

    1.  在 **名称** 字段中，输入 **images-thumbnails**。

    1.  在 **公共访问级别** 列表中，选择 **Blob（仅限 blob 匿名读取访问）**。

    1.  选择 **确定**。

1.  在 **容器** 部分，选择新创建的 **images** 容器。

1. 在 **容器** 边栏选项卡中，选择 **上传**。

1. 在显示的 **上传 blob** 窗口中，执行以下操作：

    1.  在 **文件** 部分，选择 **文件夹** 图标。

    1.  在显示的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **grilledcheese.jpg** 文件，然后选择 **打开**。

    1.  确保 **如果文件已存在，请覆盖** 复选框已选中。

    1.  选择 **上传**。

1. 等待 blob 上传完成再继续本实验室。

#### 任务 4：创建 API 应用

1.  在门户的左侧导航窗格，单击 **+ 创建资源**。

1.  在 **新建** 边栏选项卡顶部，找到 **搜索市场** 字段。

1.  在搜索字段中，输入 **API**，然后按 Enter 键。

1.  在 **全部内容** 搜索结果边栏选项卡中，选择 **API 应用** 结果。

1.  在 **API 应用** 边栏选项卡中，选择 **创建**。

1.  在第二个 **API 应用** 边栏选项卡中，执行以下操作：
    
    1.  在 **应用名称**字段中，输入 **imgapi\[*your name in lowercase*\]**。
    
    1.  将 **订阅** 字段保留设置为默认值。
    
    1.  在 **资源组** 部分，选择 **使用现有**，然后选择 **ManagedPlatform**。
    
    1.  将 **应用服务计划/位置** 字段保留设置为默认值。
    
    1.  将 **Application Insights** 字段保留设置为默认值。
    
    1.  选择 **创建**。

1.  等待创建任务完成后，再继续本实验室。

#### 任务 5：配置 API 应用

1.  在门户左侧的导航窗格中，选择 **资源组**。

1.  在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgapi\** API 应用。

1.  在 **API 应用** 边栏选项卡中，在边栏选项卡左侧的 **设置** 部分，选择 **配置** 链接。

1.  在 **配置** 部分，执行以下操作：
    
    1.  选择 **应用程序设置** 标签。
    
    1.  选择 **+ 新建应用程序设置**。
    
    1.  在出现的 **添加/编辑应用程序设置** 弹窗中，在 **名称** 字段，输入 **StorageConnectionString**。
    
    1.  在 **值** 字段中，输入之前在本实验室中复制的 **存储连接字符串**。
    
    1.  将 **部署槽位设置** 字段保留设置为默认值。

    1.  选择 **确定** 关闭弹出窗口并返回到 **配置** 部分。
    
    1.  在边栏选项卡顶部单击 **保存** 以保留设置。

1.  等待应用程序设置保存后再继续本实验室。

1.  在 **API 应用** 边栏选项卡中，在边栏选项卡左侧的 **设置** 部分，选择 **属性** 链接。

1.  在 **属性** 部分，复制 **URL** 字段的值。你将稍后在实验室中使用此值。

#### 任务 6：将 ASP.NET Core Web 应用程序部署到 API 应用

1.  在任务栏上，选择 **Visual Studio Code** 图标。

1.  在 **文件** 菜单上，选择 **打开文件夹**。

1.  在打开的“文件资源管理器”窗格中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\API**，然后选择 **选择文件夹**。

1.  在“Visual Studio Code”窗口的 **资源管理器** 窗格中，展开 **Controllers** 文件夹并双击 **ImagesController.cs** 文件以在编辑器中打开文件。

1.  在编辑器 **ImagesController** 类的第 27 行，观察 **GetCloudBlobContainer** 方法和用于检索容器的代码。

1.  在 **ImagesController** 类的第 38 行，观察 **Get** 方法和用于从 **images** 容器匿名检索所有 blob 的代码。

1.  在 **ImagesController** 类的第 74 行，观察 **Post** 方法和用于将上传图像保存到 Azure 存储的代码。

1.  在任务栏上，选择 **Windows** **PowerShell** 图标。

1.  在打开的命令提示符中，输入以下命令并按 Enter 键以登录 Azure CLI：

```
az login
```

1. 在显示的 **Microsoft Edge** 窗口中，执行以下操作：
    
    1.  输入 Microsoft 帐户的 **电子邮件地址**。
    
    2.  选择 **下一步**。
    
    3.  输入 Microsoft 帐户的 **密码**。
    
    4.  选择 **登录**。

1. 返回当前打开的 **命令提示符** 应用程序。等待登录过程完成。

1. 在命令提示符下，输入以下命令并按 Enter 键以列出 **ManagedPlatform** 资源组中的所有 **应用**：

```
az webapp list --resource-group ManagedPlatform
```

1. 在命令提示符下，输入以下命令并按 Enter 键以查找具有前缀 **imgapi\** 的 **应用**：

```
az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgapi')]"
```

1. 输入以下命令并按 Enter 键以仅打印具有前缀 **imgapi\** 的单应用的名称：

```
az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgapi')].{Name:name}" --output tsv
```

1. 输入以下命令并按 Enter 键以将当前目录更改为包含实验室文件的 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\API** 目录：

```
cd F:\Labfiles\02\Starter\API\
```

1. 输入以下命令并按 Enter 键以将 **api.zip** 文件部署到你之前在此实验室中创建的 **API 应用**：

```
az webapp deployment source config-zip --resource-group ManagedPlatform --src api.zip --name <name-of-your-api-app>
```

    > **注**：用你之前在本实验室中创建的 API 应用名称替换 **\<name-of-your-api-app\>** 占位符。你最近在之前步骤中查询了此应用的名称。

1. 等待部署完成后再继续本实验室。

1. 在门户左侧，选择 **资源组** 链接。

1. 在 **资源组** 边栏选项卡中，找到并选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1. 在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgapi\** *API 应用*。

1. 在 **API 应用** 边栏选项卡中，选择 **浏览** 按钮。

1. 执行网站根目录的 **GET** 请求并观察返回的 JSON 文件。此数组应包含你在 **Azure 存储** 帐户中单个上传的映像的 URL。

1. 返回显示 **Azure 门户** 的浏览器窗口。

#### 回顾

在本练习中，你在 Azure 中创建了一个 API 应用程序，然后使用 Azure CLI 和 Kudu 的 zip 部署实用程序将 ASP.NET Core Web 应用程序部署到 API 应用。

### 练习 2：使用 Azure Web 应用程序构建前端 Web 应用

#### 任务 1：创建 Web 应用

1.  在 Azure 门户的左侧导航窗格中，选择 **+ 创建资源**。

1.  在 **新建** 边栏选项卡顶部，找到 **搜索市场** 字段。

1.  在搜索字段中，输入 **Web**，然后按 Enter 键。

1.  在 **全部内容** 搜索结果边栏选项卡中，选择 **Web 应用** 结果。

1.  在 **Web 应用** 边栏选项卡中，选择 **创建**。

1.  在第二个 **Web 应用** 边栏选项卡中，执行以下操作：
    
    1.  在 **应用名称** 字段中，输入 **imgweb\[*your name in lowercase*\]**。
    
    1.  将 **订阅** 字段保留设置为默认值。
    
    1.  在 **资源组** 部分，选择 **使用现有**，然后选择 **ManagedPlatform**。
    
    1.  在 **发布** 部分，选择 **代码**。
    
    1.  在 **运行时堆栈** 部分，选择 **NET Core 2.2**。
    
    1.  在 **操作系统** 部分，选择 **Windows**。

    1. 在 **区域** 下拉列表中，选择 **美国东部**。
    
    1.  将 **计划（美国东部）** 字段保留设置为默认值。
    
    1.  将 **Sku 和大小** 字段保留设置为默认值。
    
    1.  选择 **查看并创建**。

1. 在 **查看并创建** 标签中，观察设置，然后单击 **创建**。

1.  等待创建任务完成后，再继续本实验室。

#### 任务 2：配置 Web 应用

1.  在门户左侧的导航窗格上，选择 **资源组**。

1.  在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\** Web 应用。

1.  在 **Web 应用** 边栏选项卡中，在边栏选项卡左侧的 **设置**部分，选择 **配置** 链接。

1.  在 **配置** 部分，执行以下操作：
    
    1.  选择 **应用程序设置** 标签。
    
    1.  选择 **+ 新建应用程序设置**。
    
    1.  在出现的 **添加/编辑应用程序设置** 弹窗中，在 **名称** 字段，输入 **ApiUrl**。
    
    1.  在 **值** 字段中，输入之前在本实验室中复制的 API 应用 **URL**。

        >**注**： 确保在复制到此应用程序设置的值字段的 URL 中加上协议（例如 *https://*）。
    
    1.  将 **部署槽位设置** 字段保留设置为默认值。

    1.  选择 **确定** 关闭弹出窗口并返回到 **配置** 部分。
    
    1.  在边栏选项卡顶部单击 **保存** 以保留设置。

1.  等待应用程序设置保存后再继续本实验室。

#### 任务 3：将 ASP.NET Core Web 应用程序部署到 Web 应用

1.  在任务栏上，选择 **Visual Studio Code** 图标。

1.  在 **文件** 菜单上，选择 **打开文件夹**。

1.  在打开的“文件资源管理器”窗格中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Web**，然后选择 **选择文件夹**。

1.  在“Visual Studio Code”窗口的 **资源管理器** 窗格中，展开 **Pages** 文件夹并双击 **Index.cshtml.cs** 文件以在编辑器中打开文件。

1.  在编辑器 **IndexModel** 类的第 30 行，观察 **OnGetAsync** 方法和用于从 API 映像列表检索容器的代码。

1.  在 **IndexModel** 类的第 52 行，观察 **OnPostAsync** 方法和用于将上传图像传输到后端 API 的代码。

1.  在任务栏上，选择 **Windows** **PowerShell** 图标。

1.  在打开的命令提示符中，输入以下命令并按 Enter 键以登录 Azure CLI：

```
az login
```

1.  在显示的窗口中，执行以下操作：
    
    1.  输入 Microsoft 帐户的 **电子邮件地址**。
    
    1.  选择 **下一步**。
    
    1.  输入 Microsoft 帐户的 **密码**。
    
    1.  选择 **登录**。

1. 返回当前打开的 **命令提示符** 应用程序。等待登录过程完成。

1. 输入以下命令并按 Enter 键以列出 **ManagedPlatform** 资源组中的所有 **应用**：

```
az webapp list --resource-group ManagedPlatform
```

1. 在命令提示符下，输入以下命令并按 Enter 键以查找具有前缀 **imgweb\** 的 **应用**：

```
az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgweb')]"
```

1. 输入以下命令并按 Enter 键以仅打印具有前缀 **imgweb\** 的单应用的名称：

```
az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgweb')].{Name:name}" --output tsv
```

1. 输入以下命令并按 Enter 键以将当前目录更改为包含实验室文件的 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Web** 目录：

```
cd F:\Labfiles\02\Starter\Web\
```

1. 输入以下命令并按 Enter 键以将 **web.zip** 文件部署到你之前在此实验室中创建的 **Web 应用**：

```
az webapp deployment source config-zip --resource-group ManagedPlatform --src web.zip --name <name-of-your-web-app>
```

    > **注**：用你之前在本实验室中创建的 Web 应用名称替换 **\<name-of-your-web-app\>** 占位符。你最近在之前步骤中查询了此应用的名称。

1. 等待部署完成后再继续本实验室。

1. 在门户左侧的导航窗格上，选择 **资源组**。

1. 在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1. 在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\** Web 应用。

1. 在 **Web 应用** 边栏选项卡中，选择 **浏览**。

1. 观察图库中的图像列表。图库应列出之前在实验室中上传到 Azure 存储的单个图像。

1. 在 **Contoso 照片库** 网页顶部，找到 **上传新图像** 部分并执行以下操作：
    
    1.  选择 **浏览**。
    
    1.  在打开的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **bahnmi.jpg** 文件，然后选择 **打开**。
    
    1.  选择 **上传**。

1. 观察已用新图像更新的图库图像。

    > **注**： 在极少数情况下，你可能需要刷新浏览器窗口才能显示新图像。

1. 返回显示 **Azure 门户** 的浏览器窗口。

#### 回顾

在本练习中，你创建了一个 Azure Web 应用，并将现有 Web 应用程序代码部署到云中的资源。

### 练习 3：使用 Azure 存储和 Azure Functions 构建后台处理作业

#### 任务 1：创建函数应用

1.  在 Azure 门户的左侧导航窗格上，选择 **+ 创建资源**。

1.  在 **新建** 边栏选项卡顶部，找到 **搜索市场** 字段。

1.  在搜索字段中，输入 **Function**，然后按 Enter 键。

1.  在 **全部内容** 搜索结果边栏选项卡中，选择 **函数应用** 结果。

1.  在 **函数应用** 边栏选项卡中，选择 **创建**。

1.  在第二个 **函数应用** 边栏选项卡中，执行以下操作：
    
    1.  在 **应用名称** 字段中，输入 **imgfunc\[*your name in lowercase*\]**。
    
    1.  将 **订阅** 字段保留设置为默认值。
    
    1.  在 **资源组** 部分，选择 **使用现有**，然后选择 **ManagedPlatform**。
    
    1.  在 **操作系统** 部分，选择 **Windows**。
    
    1.  在 **托管计划** 列表中，选择 **消耗计划**。
    
    1.  在 **位置** 拉列表中，选择 **美国东部**。
    
    1.  在 **运行时堆栈** 列表中，选择 **NET Core**。
    
    1.  在 **存储** 部分，选择 **使用现有**，然后选择你之前在本实验室中创建的 **imgstor\** 存储帐户。
    
    1.  将 **Application Insights** 字段保留设置为默认值。
    
    1. 选择 **创建**。

1.  等待创建任务完成后，再继续本实验室。

#### 任务 2：创建 .NET Core 应用程序设置

1.  在位于门户左侧的导航菜单上，选择 **资源组** 链接。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgfunc\** 函数应用。

1.  在 **函数应用** 边栏选项卡中，选择 **平台功能** 选项卡。

1.  在 **平台功能** 选项卡中，选择位于 **常规设置** 部分的 **配置** 链接。

1.  在 **配置** 部分，执行以下操作：
    
    1.  选择 **应用程序设置** 标签。
    
    1.  选择 **+ 新建应用程序设置**。
    
    1.  在出现的 **添加/编辑应用程序设置弹窗中**，在 **名称** 字段，输入 **DOTNET_SKIP_FIRST_TIME_EXPERIENCE**。
    
    1.  在 **值** 字段中，输入 **true**。

        >**注**：``DOTNET_SKIP_FIRST_TIME_EXPERIENCE`` 应用程序设置会指示 .NET Core 禁用其内置的 NuGet 包缓存机制。在临时计算实例上，这实际上将浪费时间，还会导致 Azure Function 的生成问题。
    
    1.  将 **部署槽位设置** 字段保留设置为默认值。

    1.  选择 **确定** 关闭弹出窗口并返回到 **配置** 部分。
    
    1.  在边栏选项卡顶部单击 **保存** 以保留设置。

1.  等待应用程序设置保存后再继续本实验室。

#### 任务 3：编写一个处理 blob 的函数

1.  在门户左侧的导航窗格上，选择 **资源组**。

1.  在 **资源组** 边栏选项卡中，找到并选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgfunc\** 函数应用。

1.  在 **函数应用** 边栏选项卡中，选择 **+ 新建函数**。

1.  在 **新建 Azure 函数** 快速入门中，执行以下操作：
    
    1.  在 **选择开发环境** 标题下，选择 **在门户**。
    
    1.  选择 **继续**。
    
    1.  在 **创建函数** 标题下，选择 **更多模板…**。
    
    1.  选择 **完成并查看模板**。
    
    1.  在 **模板** 列表中，选择 **Azure Blob 存储触发器**。
    
    1.  在 **未安装扩展** 窗口中，选择 **安装**。

        >**注**：安装使用 Azure 存储 blob 所需的扩展最多需要两分钟时间。如果门户没有刷新，只需关闭 **未安装扩展** 弹出窗口并再次选择 **Azure Blob 存储触发器** 即可。

    1.  安装成功后，选择 **继续**。

    1.  在 **新建函数** 窗口中，在 **名称** 字段中输入 **ImageManager**。

    1.  在 **新建函数** 窗口中，在 **路径** 字段中输入 **images/{name}**。

    1. 在 **新建函数** 窗口中，在 **存储帐户连接** 列表中选择 **AzureWebJobsStorage**。

    1. 在 **新建函数** 窗口中，选择 **创建**。

1.  在函数编辑器右侧，选择 **查看文件** 打开选项卡。

1.  在 **查看文件** 选项卡中，选择 **添加**。

1.  在出现的文件名对话框中，输入 **function.proj**。

1.  在文件编辑器中，插入以下配置内容：

```
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
    </PropertyGroup>
    <ItemGroup>
        <PackageReference Include="SixLabors.ImageSharp" Version="1.0.0-beta0006" />
    </ItemGroup>
</Project>
```

1. 在编辑器中，选择 **保存** 以保留配置更改。

    > **注**： 此 **proj** 文件包含导入 [SixLabors.ImageSharp](https://www.nuget.org/packages/SixLabors.ImageSharp/1.0.0-beta0006) 包所需的 NuGet 包引用。
    
1.  返回 **查看文件** 选项卡，选择 **function.json** 文件以查看编辑器的函数配置。

1. 在 JSON 编辑器中，观察当前配置：

```
{
  "bindings": [
    {
      "name": "myBlob",
      "type": "blobTrigger",
      "direction": "in",
      "path": "images/{name}",
      "connection": "AzureWebJobsStorage"
    }
  ],
  "disabled": false
}
```

1. 使用以下 JSON 内容替换 JSON 配置文件的全部内容：

```
{
  "bindings": [
     {
      "name": "inputBlob",
      "type": "blobTrigger",
      "direction": "in",
      "path": "images/{name}",
      "connection": "AzureWebJobsStorage"
    },
    {
      "type": "blob",
      "name": "outputBlob",
      "path": "images-thumbnails/{name}",
      "connection": "AzureWebJobsStorage",
      "direction": "out"
    }
  ]
}
```

1. 在编辑器中，选择 **保存** 以保留配置更改。

1. 返回 **查看文件** 选项卡，选择 **run.csx** 文件以返回 **ImageManager** 函数编辑器。

1. 最小化 **查看文件** 选项卡。

    > **注**： 你可以通过选择紧靠选项卡标题右侧的箭头来最小化选项卡。

1. 在函数编辑器中，观察示例函数脚本：

```
public static void Run(Stream myBlob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
}
```

1. **删除** 所有示例代码。

1. 在编辑器中，复制并粘贴以下占位符函数：

```
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.Primitives;
    
public static void Run(Stream inputBlob, Stream outputBlob, string name, ILogger log)
{
}
```

1. 选择 **保存** 以保存脚本并编译代码。

1. 在 **运行** 方法中添加以下代码行以记录有关函数执行的信息：

```
log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");
```

1. 添加以下 **using** 语句以将输入 blob **流** 加载到图像库：

```
using (Image<Rgba32> image = Image.Load(inputBlob))
{
}
```

1. 添加 **using** 语句中的以下代码行，通过重新调整图像大小和应用灰度筛选器来转变图像：

```
image.Mutate(i => 	
    i.Resize(new ResizeOptions { Size = new Size(250, 250), Mode = ResizeMode.Max }).Grayscale()
);
```

1. 添加以下代码行以将新图像保存到输出 blob **流**：

```
image.Save(outputBlob, new JpegEncoder());
```

1. 你的 **Run** 方法现在应该类似于：

```
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.Primitives;
    
public static void Run(Stream inputBlob, Stream outputBlob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");
    using (Image<Rgba32> image = Image.Load(inputBlob))
    {
        image.Mutate(i => 	
            i.Resize(new ResizeOptions { Size = new Size(250, 250), Mode = ResizeMode.Max }).Grayscale()
        );
        image.Save(outputBlob, new JpegEncoder());
    }
}
```

1. 选择 **保存** 以再次保存脚本并编译代码。

#### 任务 4：验证 Web 解决方案

1.  在门户左侧的导航窗格上，选择 **资源组**。

1.  在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1.  在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgstor\** 存储帐户。

1.  在 存储帐户 边栏选项卡中，在边栏选项卡左侧的 **Blob 服务**部分，选择 **容器** 链接。

1.  在 **容器** 部分，选择 **images** 容器。

1.  在 **容器** 边栏选项卡中，选择 **上传**。

1.  在显示的 **上传 blob** 窗口中，执行以下操作：

    1.  在 **文件** 部分，选择 **文件夹** 图标。

    1.  在打开的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **veggie.jpg** 文件，然后选择 **打开**。

    1.  确保 **如果文件已存在，请覆盖** 复选框已选中。

    1.  选择 **上传**。

1.  等待 blob 上传完成再继续本实验室。

1.  关闭 **容器** 边栏选项卡。

1. 返回 **容器** 部分，选择 **images-thumbnails** 容器。

1. 在 **容器** 边栏选项卡中，观察 **images-thumbnails** 容器中新创建的 **veggie.jpg** 文件。

    > **注**： 新图像可能需要一到五分钟才能显示。

1. 选择 **images-thumbnails** 容器中的 **veggie.jpg** blob。

1. 在 **Blob** 边栏选项卡中，选择 **编辑 blob** 选项卡。

1. 观察 blob 内容。网页将呈现上传到容器的图像。

1. 在门户左侧的导航窗格上，选择 **资源组**。

1. 在 **资源组** 边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

1. 在 **ManagedPlatform** 边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\** Web 应用。

1. 在 **Web 应用** 边栏选项卡中，选择 **浏览**。

1. 观察图库中的图像列表。缩略图列表现在应已使用新的缩略图图像进行更新。

1. 在 **Contoso 照片库** 网页顶部，找到 **上传新图像** 部分并执行以下操作：
    
    1.  选择 **浏览**。
    
    1.  在打开的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **blt.jpg** 文件，然后选择 **打开**。
    
    1.  选择 **上传**。

1. 在 **Contoso 照片库** 网页顶部，找到 **上传新图像** 部分并执行以下操作：
    
    1.  选择 **浏览**。
    
    1.  在打开的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **sub.jpg** 文件，然后选择 **打开**。
    
    1.  选择 **上传**。

1. 在 **Contoso 照片库** 网页顶部，找到 **上传新图像** 部分并执行以下操作：
    
    1.  选择 **浏览**。
    
    1.  在打开的“文件资源管理器”对话框中，前往 **Allfiles (F):\\Allfiles\\Labs\\02\\Starter\\Images**，选择 **burger.jpg** 文件，然后选择 **打开**。
    
    1.  选择 **上传**。

1. 观察已用新图像更新的图库图像。

1. 观察页面顶部的缩略图列表。每分钟刷新一次页面，直到生成缩略图。

#### 回顾

在本练习中，你在 Azure Functions 中创建了一个后台处理作业，以处理修改和调整图像大小的计算密集型任务。

### 练习 4：清理订阅 

#### 任务 1：打开 Cloud Shell

1.  在门户顶部，选择 **Cloud Shell** 图标打开一个新的 Shell 实例。

    > **注**： **Cloud Shell** 图标使用大于符号和下划线字符表示。

1.  如果这是你第一次使用订阅打开 **Cloud Shell**，将显示 **欢迎使用 Azure Cloud Shell 向导**，帮助你在第一次使用时配置 **Cloud Shell**。在向导中执行以下操作：
    
    1.  将出现一个对话框，提示你创建新的存储帐户以开始使用 Shell。接受默认设置并选择 **创建存储**。
    
    1.  等待 **Cloud Shell** 完成首次设置程序再继续本实验室。

    > **注**： 如果你没有看到 **Cloud Shell** 配置选项，这很可能是因为你在本课程实验室中使用的是现有订阅。实验室是在你使用新订阅的假设下编写的。

1.  在门户底部的 **Cloud Shell** 命令提示符中，输入以下命令，然后按 Enter 键列出订阅中的所有资源组：

```
az group list
```

1.  输入以下命令，然后按 Enter 键查看删除资源组的可能命令列表：

```
az group delete --help
```

#### 任务 2：删除资源组

1.  输入以下命令，然后按 Enter 键删除 **ManagedPlatform** 资源组：

```
az group delete --name ManagedPlatform --no-wait --yes
```

1.  关闭门户底部的 **Cloud Shell** 窗格。

#### 任务 3：关闭活动应用程序

1.  关闭当前正在运行的 **Microsoft Edge** 应用程序。

1.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你通过移除本实验室中使用过的 **资源组** 来清理订阅。
