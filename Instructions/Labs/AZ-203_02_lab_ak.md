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

  - 使用以下凭据登录到 **Windows 10** 虚拟机：
    
    1.  **用户名**：Admin
    
    2.  **密码**：Pa55w.rd

> > **注**：讲师将为你提供实验室虚拟机登录说明。

#### 查看已安装的应用

  - 观察位于 **Windows 10** 桌面底部的任务栏。任务栏包含将在本实验室中使用的应用程序图标：
    
      - Microsoft Edge
    
      - 文件资源管理器
    
      - Windows PowerShell
    
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

### 练习 1：使用 Azure 存储和 API 应用程序构建后端 API

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

2.  在打开的浏览器窗口中，导航到 [**Azure 门户**](https://portal.azure.com) (portal.azure.com)。

3.  在登录页面，输入 Microsoft 帐户的 **电子邮件地址**。

4.  选择“**下一步**”。

5.  输入 Microsoft 帐户的 **密码**。

6.  选择“**登录**”。

> **注**：如果这是你第一次登录 Azure 门户，则会显示一个对话框，提供门户教程。选择“**开始使用**”以跳过教程并开始使用门户。

#### 任务 2：创建 Azure 存储帐户

1.  在 Azure 门户的左侧导航窗格，单击“**所有服务**”。

2.  在“**所有服务**”边栏选项卡中，选择“**存储帐户**”。

3.  在“**存储帐户**”边栏选项卡中，查看存储实例列表。

4.  在“**存储帐户**”边栏选项卡顶部，选择“**添加**”。

5.  在“**创建存储帐户**”边栏选项卡中，观察边栏选项卡顶部的选项卡，如“基本”、“标记”和“查看 + 创建”。

> **注**：每个选项卡代表工作流中创建新“**存储帐户**”的一个步骤。你可以随时选择“**查看 + 创建**”跳过剩余标签。

6.  选择“**基本**”选项卡，然后在选项卡区域内执行以下操作：
    
    1.  将“**订阅**”字段保留设置为默认值。
    
    2.  在“**资源组**”部分，选择“**新建**”，输入 **ManagedPlatform**，然后选择“**确定**”。
    
    3.  在“**存储帐户** **名称**”字段，输入 **imgstor\[*your name in lowercase*\]**。
    
    4.  在“**位置**”列表中，选择“**美国东部**”区域。
    
    5.  在“**性能**”部分，选择“**标准**”。
    
    6.  在“**帐户类型**”列表中，选择 **StorageV2（通用 v2）**。
    
    7.  在“**复制**”列表中，选择“**区域冗余存储 (ZRS)**”。
    
    8.  在“**访问层**”部分，确保“**热**”已选中。
    
    9.  选择“**查看 + 创建**”。

7.  在“**查看 + 创建**”选项卡中，查看在之前步骤中指定的选项。

8.  选择“**创建**”以使用指定的配置创建存储帐户。

9.  等待创建任务完成后再继续本实验室。

10. 在 Azure 门户的左侧导航窗格，单击“**所有服务**”。

11. 在“**所有服务**”边栏选项卡中，选择**“存储帐户”**。

12. 在显示的“**存储帐户**”边栏选项卡中，选择你之前在本实验室中创建的 **imgstor\*** 存储帐户。

13. 在“**存储帐户**”边栏选项卡中，在边栏选项卡左侧，找到“**设置**”部分并选择“**访问密钥**”。

14. 在“**访问密钥**”边栏选项卡中，选择任意一个密钥并记录“**连接字符串**”字段中的任意一个值。你将稍后在本实验室中使用此值。

> > **注**：选择哪个连接字符串无关紧要。它们可以互换。

#### 任务 3：上传示例 blob

1.  在 Azure 门户左侧导航窗格中，选择“**资源组**”。

2.  在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

3.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgstor\*** 存储帐户。

4.  在“**存储帐户**”边栏选项卡中，在边栏选项卡左侧的“**Blob 服务**”部分，选择“**Blob**”链接。

5.  在“**Blob**”部分，选择“**+ 容器**”。

6.  在“**新建容器**”窗口中，执行以下操作：
    
    1.  在“**名称**”字段中，输入 **images**。
    
    2.  在“**公共访问级别**”列表中，选择“**Blob（仅限 blob 匿名读取访问）**”。
    
    3.  选择“**确定**”。

7.  在“**Blob**”部分，再次选择“**+ 容器**”。

8.  在“**新建容器**”窗口中，执行以下操作：

<!-- end list -->

1.  在“**名称**”字段中，输入 **images-thumbnails**。

2.  在“**公共访问级别**”列表中，选择“**Blob（仅限 blob 匿名读取访问）**”。

3.  选择“**确定**”。

<!-- end list -->

9.  在“**Blob**”部分，选择新创建的“**images**”容器。

10. 在“**容器**”边栏选项卡中，选择“**上传**”。

11. 在显示的“**上传 blob**”窗口中，执行以下操作：

<!-- end list -->

1.  在“**文件**”部分，选择“**文件夹**”图标。

2.  在显示的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **grilledcheese.jpg** 文件，然后选择“**打开**”。

3.  确保“**如果文件已存在，请覆盖**”复选框已选中。

4.  选择“**上传**”。

<!-- end list -->

12. 等待 blob 上传完成再继续本实验室。

#### 任务 4：创建 API 应用

1.  在门户的左侧导航窗格，单击“**+ 创建资源**”。

2.  在“**新建**”边栏选项卡顶部，找到“**搜索市场**”字段。

3.  在搜索字段中，输入 **API**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**API 应用**”结果。

5.  在“**API 应用**”边栏选项卡中，选择“**创建**”。

6.  在第二个“**API 应用**”边栏选项卡中，执行以下操作：
    
    1.  在“**应用名称**”字段中，输入 **imgapi\[*your name in lowercase*\]**。
    
    2.  将“**订阅**”字段保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后选择“**ManagedPlatform**”。
    
    4.  将“**应用服务计划/位置**”字段保留设置为默认值。
    
    5.  将“**Application Insights**”字段保留设置为默认值。
    
    6.  选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

#### 任务 5：配置 API 应用

1.  在门户左侧的导航窗格中，选择“**资源组**”。

2.  在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

3.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgapi\*** API 应用。

4.  在“**API 应用**”边栏选项卡中，在边栏选项卡左侧的“**设置**”部分，选择“**应用程序设置**”链接。

5.  在“**应用程序设置**”部分中，执行以下操作：
    
    1.  向下滚动直到看见“**应用程序设置**”子部分。
    
    2.  选择“**+ 添加新设置**”。
    
    3.  在“**输入名称**”字段中，输入 **StorageConnectionString**。
    
    4.  在“**输入名称**”字段中，输入之前在本实验室中复制的 **Storage Connection String**。
    
    5.  将“**槽设置**”字段保留设置为默认值。
    
    6.  在边栏选项卡顶部单击“**保存**”。

6.  等待应用程序设置保存后再继续本实验室。

7.  在“**API 应用**”边栏选项卡中，在边栏选项卡左侧的“**设置**”部分，选择“**属性**”链接。

8.  在“**属性**”部分，复制“**URL**”字段的值。你将稍后在实验室中使用此值。

#### 任务 6：将 ASP.NET Core Web 应用程序部署到 API 应用

1.  在任务栏上，选择 **Visual Studio Code** 图标。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\API**，然后选择“**选择文件夹**”。

4.  在“Visual Studio Code”窗口的“**资源管理器**”窗格中，展开 **Controllers** 文件夹并双击 **ImagesController.cs** 文件以在编辑器中打开文件。

5.  在编辑器 **ImagesController** 类的第 27 行，观察 **GetCloudBlobContainer** 方法和用于检索容器的代码。

6.  在 **ImagesController** 类的第 37 行，观察 **Get** 方法和用于从 **images** 容器匿名检索所有 blob 的代码。

7.  在 **ImagesController** 类的第 74 行，观察 **Post** 方法和用于将上传图像保存到 Azure 存储的代码。

8.  在任务栏上，选择 **Windows** **PowerShell** 图标。

9.  在打开的命令提示符中，输入以下命令并按 Enter 键以登录 Azure CLI：

<!-- end list -->

    az login

10. 在显示的“**Microsoft Edge**”窗口中，执行以下操作：
    
    1.  输入 Microsoft 帐户的**电子邮件地址**。
    
    2.  选择“**下一步**”。
    
    3.  输入 Microsoft 帐户的**密码**。
    
    4.  选择“**登录**”。

11. 返回当前打开的“**命令提示符**”应用程序。等待登录过程完成。

12. 在命令提示符下，输入以下命令并按 Enter 键以列出 **ManagedPlatform** 资源组中的所有 **应用**：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform

13. 在命令提示符下，输入以下命令并按 Enter 键以查找具有前缀 **imgapi\*** 的 **应用**：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgapi')]"

14. 输入以下命令并按 Enter 键以仅打印具有前缀 **imgapi\*** 的单应用的名称：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgapi')].{Name:name}" --output tsv

15. 输入以下命令并按 Enter 键以将当前目录更改为包含实验室文件的 **Allfiles (F):\\Labfiles\\02\\Starter\\API** 目录：

<!-- end list -->

    cd F:\Labfiles\02\Starter\API\

16. 输入以下命令并按 Enter 键以将 **api.zip** 文件部署到你之前在此实验室中创建的 **API 应用**：

<!-- end list -->

    az webapp deployment source config-zip --resource-group ManagedPlatform --src api.zip --name <name-of-your-api-app>

> > **注**：用你之前在本实验室中创建的 API 应用名称替换 **\<name-of-your-api-app\>** 占位符。你最近在之前步骤中查询了此应用的名称。

17. 等待部署完成后再继续本实验室。

18. 在门户左侧，选择“**资源组**”链接。

19. 在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

20. 在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgapi\*** *API 应用*。

21. 在“**API 应用**”边栏选项卡中，选择“**浏览**”按钮。

22. 执行网站根目录的 **GET** 请求并观察返回的 JSON 文件。此数组应包含你在 **Azure 存储** 帐户中单个上传的映像的 URL。

23. 返回显示 **Azure 门户** 的浏览器窗口。

#### 回顾

在本练习中，你在 Azure 中创建了一个 API 应用程序，然后使用 Azure CLI 和 Kudu 的 zip 部署实用程序将 ASP.NET Core Web 应用程序部署到 API 应用。

### 练习 2：使用 Azure Web 应用程序构建前端 Web 应用

#### 任务 1：创建 Web 应用

1.  在 Azure 门户的左侧导航窗格中，选择“**+ 创建资源**”。

2.  在“**新建**”边栏选项卡顶部，找到“**搜索市场**”字段。

3.  在搜索字段中，输入 **Web**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**Web** **应用**”结果。

5.  在“**Web** **应用**”边栏选项卡中，选择“**创建**”。

6.  在第二个“**Web** **应用**”边栏选项卡中，执行以下操作：
    
    1.  在“**应用名称**”字段中，输入 **imgweb\[*your name in lowercase*\]**。
    
    2.  将“**订阅**”字段保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后选择“**ManagedPlatform**”。
    
    4.  在“**发布**”部分，选择“**代码**”。
    
    5.  在“**运行时堆栈**”部分，选择 **NET Core 2.2**。
    
    6.  在“**操作系统**”部分，选择“**Windows**”。
    
    7.  将“**应用服务计划/位置**”字段保留设置为默认值。
    
    8.  将“**Application Insights**”字段保留设置为默认值。
    
    9.  选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

#### 任务 2：配置 Web 应用

1.  在门户左侧的导航窗格上，选择“**资源组**”。

2.  在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

3.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\*** Web 应用。

4.  在“**Web 应用**”边栏选项卡中，在边栏选项卡左侧的“**设置**”部分，选择“**应用程序设置**”链接。

5.  在“**应用程序设置**”部分中，执行以下操作：
    
    7.  向下滚动直到看见“**应用程序设置**”子部分。
    
    8.  选择“**+ 添加新设置**”。
    
    9.  在“**输入名称**”字段中，输入 **ApiUrl**。
    
    10. 在“**输入名称**”字段中，输入之前在本实验室中复制的 API 应用 **URL**。
    
    11. 将“**槽设置**”字段保留设置为默认值。
    
    12. 在边栏选项卡顶部单击“**保存**”。

6.  等待应用程序设置保存后再继续本实验室。

#### 任务 3：将 ASP.NET Core Web 应用程序部署到 Web 应用

1.  在任务栏上，选择 **Visual Studio Code** 图标。

2.  在“**文件**”菜单上，选择“**打开文件夹**”。

3.  在打开的“文件资源管理器”窗格中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Web**，然后选择“**选择文件夹**”。

4.  在“Visual Studio Code”窗口的“**资源管理器**”窗格中，展开 **Pages** 文件夹并双击 **Index.cshtml.cs** 文件以在编辑器中打开文件。

5.  在编辑器 **IndexModel** 类的第 30 行，观察 **OnGetAsync** 方法和用于从 API 映像列表检索容器的代码。

6.  在 **IndexModel** 类的第 52 行，观察 **OnPostAsync** 方法和用于将上传图像传输到后端 API 的代码。

7.  在任务栏上，选择 **Windows** **PowerShell** 图标。

8.  在打开的命令提示符中，输入以下命令并按 Enter 键以登录 Azure CLI：

<!-- end list -->

    az login

9.  在显示的窗口中，执行以下操作：
    
    1.  输入 Microsoft 帐户的 **电子邮件地址**。
    
    2.  选择“**下一步**”。
    
    3.  输入 Microsoft 帐户的 **密码**。
    
    4.  选择“**登录**”。

10. 返回当前打开的“**命令提示符**”应用程序。等待登录过程完成。

11. 输入以下命令并按 Enter 键以列出 **ManagedPlatform** 资源组中的所有 **应用**：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform

12. 在命令提示符下，输入以下命令并按 Enter 键以查找具有前缀 **imgweb\*** 的 **应用**：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgweb')]"

13. 输入以下命令并按 Enter 键以仅打印具有前缀 **imgweb\*** 的单应用的名称：

<!-- end list -->

    az webapp list --resource-group ManagedPlatform --query "[?starts_with(name, 'imgweb')].{Name:name}" --output tsv

14. 输入以下命令并按 Enter 键以将当前目录更改为包含实验室文件的 **Allfiles (F):\\Labfiles\\02\\Starter\\Web** 目录：

<!-- end list -->

    cd F:\Labfiles\02\Starter\Web\

15. 输入以下命令并按 Enter 键以将 **web.zip** 文件部署到你之前在此实验室中创建的 **Web 应用**：

<!-- end list -->

    az webapp deployment source config-zip --resource-group ManagedPlatform --src web.zip --name <name-of-your-web-app>

> > **注**：用你之前在本实验室中创建的 Web 应用名称替换 **\<name-of-your-web-app\>** 占位符。你最近在之前步骤中查询了此应用的名称。

16. 等待部署完成后再继续本实验室。

17. 在门户左侧的导航窗格上，选择“**资源组**”。

18. 在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

19. 在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\*** Web 应用。

20. 在“**Web 应用**”边栏选项卡中，选择“**浏览**”。

21. 观察图库中的图像列表。图库应列出之前在实验室中上传到 Azure 存储的单个图像。

22. 在“**Contoso 照片库**”网页顶部，找到“**上传新图像**”部分并执行以下操作：
    
    5.  选择“**浏览**”。
    
    6.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **bahnmi.jpg** 文件，然后选择“**打开**”。
    
    7.  选择“**上传**”。

23. 观察已用新图像更新的图库图像。

> > **注**：在极少数情况下，你可能需要刷新浏览器窗口才能显示新图像。

24. 返回显示 **Azure 门户** 的浏览器窗口。

#### 回顾

在本练习中，你创建了一个 Azure Web 应用，并将现有 Web 应用程序代码部署到云中的资源。

### 练习 3：使用 Azure 存储和 Azure Functions 构建后台处理作业

#### 任务 1：创建函数应用

1.  在 Azure 门户的左侧导航窗格上，选择“**+ 创建资源**”。

2.  在“**新建**”边栏选项卡顶部，找到“**搜索市场**”字段。

3.  在搜索字段中，输入 **Function**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**函数** **应用**”结果。

5.  在“**函数** **应用**”边栏选项卡中，选择“**创建**”。

6.  在第二个“**函数** **应用**”边栏选项卡中，执行以下操作：
    
    1.  在“**应用名称**”字段中，输入 **imgfunc\[*your name in lowercase*\]**。
    
    2.  将“**订阅**”字段保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后选择“**ManagedPlatform**”。
    
    4.  在“**操作系统**”部分，选择“**Windows**”。
    
    5.  在“**托管计划**”列表中，选择“**消耗计划**”。
    
    6.  在“**位置**”拉列表中，选择“**美国东部**”。
    
    7.  在“**运行时堆栈**”列表中，选择“**.NET**”。
    
    8.  在“**存储**”部分，选择“**使用现有**”，然后选择你之前在本实验室中创建的 **imgstor\*** 存储帐户。
    
    9.  将“**Application Insights**”字段保留设置为默认值。
    
    10. 选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

#### 任务 2：编写一个处理 blob 的函数

1.  在门户左侧的导航窗格上，选择“**资源组**”。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

3.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgfunc\*** 函数应用。

4.  在“**函数应用**”边栏选项卡中，选择“**+ 新建函数**”。

5.  在“**新建 Azure 函数**”快速入门中，执行以下操作：
    
    1.  在“**选择开发环境**”标题下，选择“**在门户**”。
    
    2.  选择“**继续**”。
    
    3.  在“**创建函数**”标题下，选择“**更多模板…**”。
    
    4.  选择“**完成并查看模板**”。
    
    5.  在“**模板**”列表中，选择“**Azure Blob 存储触发器**”。
    
    6.  在“**未安装扩展**”窗口中，选择“**安装**”。

> > **注**：安装使用 Azure 存储 blob 所需的扩展最多需要两分钟时间。如果门户没有刷新，只需关闭“**未安装扩展**”弹出窗口并再次选择“**Azure Blob 存储触发器**”即可。

7.  安装成功后，选择“**继续**”。

8.  在“**新建函数**”窗口中，在“**名称**”字段中输入 **ImageManager**。

9.  在“**新建函数**”窗口中，在“**路径**”字段中输入 **images/{name}**。

10. 在“**新建函数**”窗口中，在“**存储帐户连接**”列表中选择 **AzureWebJobsStorage**。

11. 在“**新建函数**”窗口中，选择“**创建**”。

<!-- end list -->

6.  在函数编辑器右侧，选择“**查看文件**”打开选项卡。

7.  在“**查看文件**”选项卡中，选择“**上传**”。

8.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter**，选择 **function.proj** 文件，然后选择“**打开**”。

9.  返回“**查看文件**”选项卡，选择 **function.json** 文件以查看编辑器的函数配置。

10. 在 JSON 编辑器中，观察当前配置：

<!-- end list -->

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

11. 使用以下 JSON 内容替换 JSON 配置文件的全部内容：

<!-- end list -->

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

12. 在编辑器中，选择“**保存**”以保留配置更改。

13. 返回“**查看文件**”选项卡，选择 **run.csx** 文件以返回 **ImageManager** 函数编辑器。

14. 最小化“**查看文件**”选项卡。

> > **注**：你可以通过选择紧靠选项卡标题右侧的箭头来最小化选项卡。

15. 在函数编辑器中，观察示例函数脚本：

<!-- end list -->

    public static void Run(Stream myBlob, string name, ILogger log)
    {
        log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
    }

16. **删除**所有示例代码。

17. 在编辑器中，复制并粘贴以下占位符函数：

<!-- end list -->

    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using SixLabors.Primitives;
    
    public static void Run(Stream inputBlob, Stream outputBlob, string name, ILogger log)
    {
    }

18. 选择“**保存**”以保存脚本并编译代码。

19. 在“**运行**”方法中添加以下代码行以记录有关函数执行的信息：

<!-- end list -->

    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");

20. 添加以下 **using** 块以将输入 blob **流** 载入图像库：

<!-- end list -->

    using (Image<Rgba32> image = Image.Load(inputBlob))
    {
    }

21. 添加 **using** 块中的以下代码行，通过重新调整图像大小和应用灰度筛选器来转变图像：

<!-- end list -->

    image.Mutate(i => 	
        i.Resize(new ResizeOptions { Size = new Size(250, 250), Mode = ResizeMode.Max }).Grayscale()
    );

22. 添加以下代码行以将新图像保存到输出 blob **流**：

<!-- end list -->

    image.Save(outputBlob, new JpegEncoder());

23. 你的 **Run** 方法现在应该类似于：

<!-- end list -->

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

24. 选择“**保存**”以再次保存脚本并编译代码。

#### 任务 3：验证 Web 解决方案

1.  在门户左侧的导航窗格上，选择“**资源组**”。

2.  在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

3.  在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgstor\*** 存储帐户。

4.  在“**存储帐户**”边栏选项卡中，在边栏选项卡左侧的“**Blob 服务**”部分，选择“**Blob**”链接。

5.  在“**Blob**”部分，选择“**images**”容器。

6.  在“**容器**”边栏选项卡中，选择“**上传**”。

7.  在显示的“**上传 blob**”窗口中，执行以下操作：

<!-- end list -->

1.  在“**文件**”部分，选择“**文件夹**”图标。

2.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **veggie.jpg** 文件，然后选择“**打开**”。

3.  确保“**如果文件已存在，请覆盖**”复选框已选中。

4.  选择“**上传**”。

<!-- end list -->

8.  等待 blob 上传完成再继续本实验室。

9.  关闭“**容器**”边栏选项卡。

10. 返回“**Blob**”部分，选择“**images-thumbnails**”容器。

11. 在“**容器**”边栏选项卡中，观察“**images-thumbnails**”容器中新创建的 **veggie.jpg** 文件。

> > **注**：新图像可能需要一到五分钟才能显示。

12. 选择 **images-thumbnails** 容器中的 **veggie.jpg** blob。

13. 在“**Blob**”边栏选项卡中，选择“**编辑 blob**”选项卡。

14. 观察 blob 内容。网页将呈现上传到容器的图像。

15. 在门户左侧的导航窗格上，选择“**资源组**”。

16. 在“**资源组**”边栏选项卡中，选择你之前在本实验室中创建的 **ManagedPlatform** 资源组。

17. 在“**ManagedPlatform**”边栏选项卡中，选择你之前在本实验室中创建的 **imgweb\*** Web 应用。

18. 在“**Web 应用**”边栏选项卡中，选择“**浏览**”。

19. 观察图库中的图像列表。缩略图列表现在应已使用新的缩略图图像进行更新。

20. 在“**Contoso 照片库**”网页顶部，找到“**上传新图像**”部分并执行以下操作：
    
    1.  选择“**浏览**”。
    
    2.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **blt.jpg** 文件，然后选择“**打开**”。
    
    3.  选择“**上传**”。

21. 在“**Contoso 照片库**”网页顶部，找到“**上传新图像**”部分并执行以下操作：
    
    4.  选择“**浏览**”。
    
    5.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **sub.jpg** 文件，然后选择“**打开**”。
    
    6.  选择“**上传**”。

22. 在“**Contoso 照片库**”网页顶部，找到“**上传新图像**”部分并执行以下操作：
    
    7.  选择“**浏览**”。
    
    8.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\02\\Starter\\Images**，选择 **burger.jpg** 文件，然后选择“**打开**”。
    
    9.  选择“**上传**”。

23. 观察已用新图像更新的图库图像。

24. 观察页面顶部的缩略图列表。每分钟刷新一次页面，直到生成了所有四个缩略图。

#### 回顾

在本练习中，你在 Azure Functions 中创建了一个后台处理作业，以处理修改和调整图像大小的计算密集型任务。

### 练习 4：清理订阅 

#### 任务 1：打开 Cloud Shell

1.  在门户顶部，选择 **Cloud Shell** 图标打开一个新的 Shell 实例。

2.  在门户底部的 **Cloud Shell** 命令提示符中，输入以下命令，然后按 Enter 键列出订阅中的所有资源组：

<!-- end list -->

    az group list

3.  输入以下命令，然后按 Enter 键查看删除资源组的可能命令列表：

<!-- end list -->

    az group delete --help

#### 任务 2：删除资源组

1.  输入以下命令，然后按 Enter 键删除 **ManagedPlatform** 资源组：

<!-- end list -->

    az group delete --name ManagedPlatform --no-wait --yes

2.  关闭门户底部的“**Cloud Shell**”窗格。

#### 任务 3：关闭活动应用程序

1.  关闭当前正在运行的 **Microsoft Edge** 应用程序。

2.  关闭当前正在运行的 **Visual Studio Code** 应用程序。

#### 回顾

在本练习中，你通过移除本实验室中使用过的 **资源组** 来清理订阅。
