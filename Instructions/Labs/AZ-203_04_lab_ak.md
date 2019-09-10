---
实验室：
    标题：“实验室：跨服务安全访问资源机密”
    类型：“答案”
    模块：“模块 4：实现 Azure 安全”
---

# 实验室：跨服务安全访问资源机密
# 学生实验室答案

## Microsoft Azure 用户界面

鉴于 Microsoft 云工具的动态特性，Azure 用户界面 (UI) 在此培训内容开发后可能会发生更改。这些更改可能会导致实验室说明和实验室步骤不匹配。

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

### 练习 1：创建 Azure 资源

#### 任务 1：打开 Azure 门户

1.  在任务栏上，选择 **Microsoft Edge** 图标。

2.  在打开的浏览器窗口中，导航到 **Azure 门户** ([portal.azure.com](https://portal.azure.com))。

3.  输入 Microsoft 帐户的 **电子邮件地址**。

4.  选择“**下一步**”。

5.  输入 Microsoft 帐户的 **密码**。

6.  选择“**登录**”。

> > 注：如果这是你第一次登录 **Azure 门户**，则会出现一个对话框，提供门户教程。选择“**开始使用**”以跳过教程并开始使用门户。

#### 任务 2：创建 Azure 存储帐户

1.  在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

2.  在“**所有服务**”边栏选项卡中，选择“**存储帐户**”。

3.  在“**存储帐户**”边栏选项卡中，查看存储实例列表。

4.  在“**存储帐户**”边栏选项卡顶部，选择“**添加**”。

5.  在“**创建存储帐户**”边栏选项卡中，观察边栏选项卡顶部的选项卡，如“**基本**”。

> 注：每个选项卡代表工作流中创建新“**存储帐户**”的一个步骤。你可以随时选择“**查看 + 创建**”跳过剩余标签。

6.  在“**基本**”选项卡中，执行以下操作：
    
    1.  将“**订阅**”文本框保留设置为默认值。
    
    2.  在“**资源组**”部分，选择“**新建**”，输入 **SecureFunction**，然后选择“**确定**”。
    
    3.  在“**存储帐户** **名称**”字段中，输入 **securestor\[your name in lowercase\]**。
    
    4.  在“**位置**”下拉列表中，选择“**美国东部**”地区。
    
    5.  在“**性能**”部分，选择“**标准**”。
    
    6.  在“**帐户类型**”下拉列表中，选择“**StorageV2（通用 v2）**”。
    
    7.  在“**复制**”下拉列表中，选择“**本地冗余存储 (LRS)**”。
    
    8.  在“**访问层**”部分，确保 **Hot** 已选中。
    
    9.  选择“**查看 + 创建**”。

7.  在“**查看 + 创建**”选项卡中，查看在之前步骤中选择的选项。

8.  选择“**创建**”以使用指定的配置创建存储帐户。

9.  等待创建任务完成后，再继续本实验室。

10. 在 Azure 门户左侧的导航窗格中，单击“**更多服务**”。

11. 在“**所有服务**”边栏选项卡中，选择“**存储帐户**”。

12. 在“**存储帐户**”边栏选项卡中，选择具有前缀 **securestor** 的存储帐户实例。

13. 在“**存储帐户**”边栏选项卡中，找到边栏选项卡左侧的“**设置**”部分，选择“**访问密钥**”链接。

14. 在“**访问密钥**”边栏选项卡中，选择任意一个密钥并记录“**连接字符串**”字段的任意一个值。你将稍后在本实验室中使用此值。

> > 注：选择使用哪个连接字符串无关紧要。它们可以互换。

#### 任务 3：创建 Azure 密钥保管库

1.  在位于门户左侧的导航菜单上，选择“**+ 创建资源**”链接。

2.  在顶部的“**新建**”边栏选项卡，找到特色服务列表上方的“**搜索市场**”文本框。

3.  在搜索文本框中，输入 **Vault**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**密钥保管库**”结果。

5.  在“**密钥保管库**”边栏选项卡中，选择“**创建**”。

6.  在“**创建密钥保管库**”边栏选项卡中，执行以下操作：
    
    1.  在“**名称**”文本框中，输入 **securevault\[your name in lowercase\]**。
    
    2.  将“**订阅**”文本框保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后从列表选择“**SecureFunction**”。
    
    4.  在“**位置**”下拉列表中，选择“**美国东部**”。
    
    5.  将“**定价层**”文本框保留设置为默认值。
    
    6.  将“**访问策略**”文本框保留设置为默认值。
    
    7.  将“**虚拟网络访问**”文本框保留设置为默认值。
    
    8.  选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

#### 任务 4：创建 Azure 函数应用

1.  在位于门户左侧的导航菜单上，选择“**+ 创建资源**”链接。

2.  在顶部的“**新建**”边栏选项卡，找到特色服务列表上方的“**搜索市场**”文本框。

3.  在搜索文本框中，输入 **Function**，然后按 Enter 键。

4.  在“**全部内容**”搜索结果边栏选项卡中，选择“**函数应用**”结果。

5.  在“**函数应用**”边栏选项卡中，选择“**创建**”。

6.  在“**创建函数应用**”边栏选项卡中，执行以下操作：
    
    1.  在“**应用名称**”文本框中，输入 **securefunc\[your name in lowercase\]**。
    
    2.  将“**订阅**”文本框保留设置为默认值。
    
    3.  在“**资源组**”部分，选择“**使用现有**”，然后从列表选择“**SecureFunction**”。
    
    4.  在“**操作系统**”部分，选择“**Windows**”。
    
    5.  在“**托管计划**”下拉列表中，选择“**消耗计划**”。
    
    6.  在“**位置**”下拉列表中，选择“**美国东部**”。
    
    7.  在“**运行时堆栈**”下拉列表中，选择“**.NET**”。
    
    8.  在“**存储**”部分，选择“**使用现有**”，然后从列表选择“**securestor\[your name in lowercase\]**”。
    
    9.  将“**Application Insights**”文本框保留设置为默认值。
    
    10. 选择“**创建**”。

7.  等待创建任务完成后，再继续本实验室。

#### 回顾

在本练习中，你创建了所有将用于此实验室的资源。

### 练习 2：配置机密和标识 

#### 任务 1：配置系统分配的托管服务标识

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securefunc\*** 函数应用。

4.  在“**函数应用**”边栏选项卡中，选择“**平台功能**”选项卡。

5.  在“**平台功能**”选项卡中，选择位于“**网络**”部分的“**标识**”链接。

6.  在“**标识**”边栏选项卡中，找到“**系统分配的**”选项卡，然后执行以下操作：
    
    1.  在“**状态**”部分，选择“**开**”。
    
    2.  选择“**保存**”。
    
    3.  在确认对话框中选择“**是**”。

7.  等待系统分配的托管标识创建完成后再继续本实验室。

#### 任务 2：创建密钥保管库机密

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securevault\*** 密钥保管库。

4.  在“**密钥保管库**”边栏选项卡中，选择位于“**设置**”部分的“**机密**”链接。

5.  在“**机密**”窗格中，选择“**生成/导入**”。

6.  在“**创建机密**”边栏选项卡中，执行以下操作：
    
    1.  在“**上传选项**”下拉列表中，选择“**手动**”。
    
    2.  在“**名称**”文本框中，输入 **storagecredentials**。
    
    3.  在“**值**”文本框中，输入之前在本实验室中记录的存储帐户 **连接字符串**。
    
    4.  将“**内容类型**”文本框保留设置为默认值。
    
    5.  将“**设置激活日期**”文本框保留设置为默认值。
    
    6.  将“**设置到期日期**”文本框保留设置为默认值。
    
    7.  在“**启用**”部分，选择“**是**”。
    
    8.  选择“**创建**”。

7.  等待机密创建完成后再继续本实验室。

8.  返回“**机密**”窗格，在列表中选择 **storagecredentials** 项目。

9.  在“**版本**”窗格中，选择最新版本的 **storagecredentials** 机密。

10. 在“**机密版本**”窗格中，执行以下操作。
    
    9.  观察最新版本秘密的元数据。
    
    10. 选择“**显示机密值**”以查看机密的值。
    
    11. 记录“**机密标识符**”文本框的值，稍后将在本实验室中用到。

> > 注：是记录“**机密标识符**”字段中的值，而不是“**机密值**”字段中的值。

#### 任务 3：配置密钥保管库访问策略

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securevault\*** 密钥保管库。

4.  在“**密钥保管库**”边栏选项卡中，选择位于“**设置**”部分的“**访问策略**”链接。

5.  在“**访问政策**”窗格中，选择“**新增**”。

6.  在“**添加访问策略**”边栏选项卡中，执行以下操作：
    
    1.  选择“**选择主体**”链接。
    
    2.  在“**主体**”边栏选项卡中，找到并选择名为 **securefunc\[your name in lowercase\]** 的服务主体，然后选择“**选择**”。
    
    3.  将“**密钥权限**”列表保留设置为默认值。
    
    4.  在“密钥权限”下拉列表中，选择 GET 权限。
    
    5.  将“**证书权限**”列表保留设置为默认值。
    
    6.  将“**授权应用程序**”文本框保留设置为默认值。
    
    7.  选择“**确定**”。

7.  返回“**访问策略**”窗格，选择“**保存**”。

8.  等待访问策略更改保存后再继续本实验室。

#### 回顾

在本练习中，你为函数应用创建了服务器分配的托管服务标识，然后为该标识提供了相应的权限，以获取密钥保管库中的机密值。最后，你创建了一个将在函数应用中使用的机密。

### 练习 3：编写函数应用代码 

#### 任务 1：创建密钥保管库派生的应用程序设置 

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securefunc\*** 函数应用。

4.  在“**函数应用**”边栏选项卡中，选择“**平台功能**”选项卡。

5.  在“**平台功能**”选项卡中，选择位于“**常规设置**”部分的“**应用程序设置**”链接。

6.  在“**应用程序设置**”选项卡中，执行以下操作：
    
    1.  向下滚动直到看见“**应用程序设置**”部分。
    
    2.  选择“**+ 添加新设置**”。
    
    3.  在“**输入名称**”文本框中，输入 **StorageConnectionString**。
    
    4.  在“**输入值**”文本框中，使用下列语法构造一个值：**@Microsoft.KeyVault(SecretUri=\<Secret Identifier\>)**

> > 注：你需要使用以上语法构建一个**机密标识符**引用。例如，如果机密标识符为 **https://securevaultstudent.vault.azure.net/secrets/storagecredentials/17b41386df3e4191b92f089f5efb4cbf**，则值为 **@Microsoft.KeyVault(SecretUri= https://securevaultstudent.vault.azure.net/secrets/storagecredentials/17b41386df3e4191b92f089f5efb4cbf)**

5.  将“**槽设置**”文本框保留设置为默认值。

6.  滚动回选项卡顶部，然后选择“**保存**”。

<!-- end list -->

7.  等待应用程序设置保存后再继续此实验室。

#### 任务 2：创建 HTTP 触发的函数

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securefunc\*** 函数应用。

4.  在“**函数应用**”边栏选项卡中，选择“**+ 新建函数**”。

5.  在“**新建 Azure 函数**”快速入门中，执行以下操作：
    
    1.  在“**选择开发环境**”标题下，选择“**在门户**”。
    
    2.  选择“**继续**”。
    
    3.  在“**选择函数**”标题下，选择“**更多模板…**”。
    
    4.  选择“**完成并查看模板**”。
    
    5.  在“**模板**”下拉列表中，选择“**HTTP 触发器**”。
    
    6.  在“**新函数**”弹出窗口中，找到“**名称**”文本框并输入 **FileParser**。
    
    7.  在“**新函数**”弹出窗口中，找到“**授权级别**”列表并选择“**匿名**”。
    
    8.  在“**新建函数**”弹出窗口中，选择“**创建**”。

6.  在函数编辑器中，观察示例函数脚本：

\#r "Newtonsoft.Json"

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;

public static async Task\<IActionResult\> Run(HttpRequest req, ILogger log)

{

log.LogInformation("C\# HTTP trigger function processed a request.");

string name = req.Query\["name"\];

string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

dynamic data = JsonConvert.DeserializeObject(requestBody);

name = name ?? data?.name;

return name \!= null

? (ActionResult)new OkObjectResult($"Hello, {name}")

: new BadRequestObjectResult("Please pass a name on the query string or in the request body");

}

7.  **删除** 所有示例代码。

8.  在函数编辑器中，复制并粘贴以下占位符函数：

using System.Net;

using Microsoft.AspNetCore.Mvc;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

return new OkObjectResult("Test Successful");

}

9.  选择“**保存并运行**”以保存脚本并执行函数的测试执行。

10. 脚本第一次执行时，“**测试**”和“**日志**”窗格将自动显示。

11. 观察“**测试**”窗格中的“**输出**”文本框。你现在应该看到函数返回“**测试成功**”值。

#### 任务 3：测试应用程序设置

1.  删除脚本 **Run** 方法中的现有代码。

2.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

}

3.  添加以下代码行，以通过使用 **Environment.GetEnvironmentVariable** 方法获取 **StorageConnectionString** 应用程序设置的值：

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

4.  添加以下代码行，以通过使用 **OkObjectResult** 类构造函数返回 **connectionString** 变量的值：

return new OkObjectResult(connectionString);

5.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

return new OkObjectResult(connectionString);

}

6.  选择“**保存并运行**”以保存脚本并执行函数的测试执行。

7.  观察“**测试**”窗格中的“**输出**”文本框。你现在应该看到函数返回的连接字符串。

#### 回顾

在本练习中，你安全地使用了服务标识读取 **Azure 密钥保管库**中存储的机密值并将该值作为 **Azure Function** 的结果返回。

### 练习 4：访问存储帐户 blob

#### 任务 1：上传示例存储 blob

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securestor\*** 存储帐户。

4.  在“**存储帐户**”边栏选项卡中，选择位于边栏选项卡左侧“**Blob 服务**”部分的“**Blob**”链接。

5.  在“**Blob**”部分，选择“**+ 容器**”。

6.  在“**新建容器**”弹出窗口中，执行以下操作：
    
    1.  在“**名称**”文本框中，输入 **drop**。
    
    2.  在“**公共访问级别**”下拉列表中，选择“**Blob（仅限 blob 匿名读取访问）**”。
    
    3.  选择“**确定**”。

7.  返回“**Blob**”部分，选择新创建的“**drop**”容器。

8.  在“**容器**”边栏选项卡中，选择“**上传**”。

9.  在“**上传 blob**”弹出窗口中，执行以下操作：
    
    4.  在“**文件**”部分，选择“**文件夹**”图标。
    
    5.  在“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\04\\Starter**，选择 **records.json** 文件，然后选择“**打开**”。
    
    6.  确保“**如果文件已存在，请覆盖**”已选中。
    
    7.  选择“**上传**”。

10. 等待 blob 上传完成再继续本实验室。

11. 返回“**容器**”边栏选项卡，从 blob 列表选择 **records.json** blob。

12. 在“**Blob**”边栏选项卡中，查看 blob 元数据。

13. 复制 blob 的 **URL**。

14. 在任务栏上，右键选择 **Microsoft Edge** 图标，然后选择“**新窗口**”。

15. 在新的浏览器窗口中，导航到你复制的 blob **URL**。

16. 你现在应该看到 blob 的 **JSON** 内容。关闭显示 **JSON** 内容的浏览器窗口。

17. 返回 **Azure 门户**浏览器窗口。

18. 关闭“**Blob**”边栏选项卡。

19. 返回“**容器**”边栏选项卡，选择位于边栏选项卡顶部的“**更改访问级别策略**”。

20. 在显示的“**更改访问级别**”弹出窗口中，执行以下操作：
    
    8.  在“**公共访问级别**”下拉列表中，选择“**专用（无匿名访问）**”。
    
    9.  选择“**确定**”。

21. 在任务栏上，右键选择 **Microsoft Edge** 图标，然后选择“**新窗口**”。

22. 在新的浏览器窗口中，导航到你复制的 blob **URL**。

23. 你现在应看到一条指示找不到资源的错误消息。

> > 注：如果你没有看到错误消息，则浏览器可能已缓存该文件。使用 **Ctrl+F5** 刷新页面，直到看到错误消息。

#### 任务 2：配置存储帐户 DK

1.  在位于门户左侧的导航菜单上，选择“**资源组**”链接。

2.  在“**资源组**”边栏选项卡中，找到并选择你之前在本实验室中创建的 **SecureFunction** 资源组。

3.  在“**SecureFunction**”边栏选项卡中，选择你之前在本实验室中创建的 **securefunc\*** 函数应用。

4.  在“**函数应用**”功能选项卡中，找到并选择现有的 **FileParser** 函数以打开函数编辑器。

> > 注：你可能需要在边栏选项卡左侧的菜单中展开“**函数**”选项。

5.  在编辑器右侧，选择“**查看文件**”打开选项卡。

6.  在“**查看文件**”选项卡中，选择“**上传**”。

7.  在打开的“文件资源管理器”对话框中，转到 **Allfiles (F):\\Labfiles\\04\\Starter**，选择 **function.proj** 文件，然后选择“**打开**”。

8.  选择 **function.proj** 文件以查看文件内容。

9.  选择 **run.csx** 文件以返回 **FileParser** 函数编辑器。

10. 最小化“**查看文件**”选项卡。

> > 注：你可以通过选择紧靠选项卡标题右侧的箭头来最小化选项卡。

11. 在编辑器中，删除脚本 **Run** 方法中的现有代码。

12. 在代码文件顶部，添加以下代码行以为 **Microsoft.WindowsAzure.Storage** 命名空间创建 **using** 块：

using Microsoft.WindowsAzure.Storage;

13. 添加以下代码行以为 **Microsoft.WindowsAzure.Storage.Blob** 命名空间创建 **using** 块：

using Microsoft.WindowsAzure.Storage.Blob;

14. **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

}

#### 任务 3：编写存储帐户代码

1.  在 **Run** 方法中添加以下代码行，以通过使用 **Environment.GetEnvironmentVariable** 方法获取 **StorageConnectionString** 应用程序设置的值：

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

2.  添加以下代码行，以使用 **CloudStorageAccount.Parse** 静态方法创建一个 **CloudStorageAccount** 类新实例，传入 *connectionString* 变量：

CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

3.  添加以下代码行，以使用 **CloudStorageAccount.CreateCloudBlobClient** 方法创建一个让你在存储帐户中访问 blob 的 **CloudBlobClient** 类新实例：

CloudBlobClient blobClient = account.CreateCloudBlobClient();

4.  添加以下代码行，以在传入 **drop** 容器名称时使用 **CloudBlobClient.GetContainerReference** 方法创建一个引用之前在本实验室中创建的容器的 **CloudBlobContainer** 类新实例：

CloudBlobContainer container = blobClient.GetContainerReference("drop");

5.  添加以下代码行，以在传入 **records.json** blob 名称时使用 **CloudBlobContainer.GetBlockBlobReference** 方法创建一个引用之前在本实验室中上传的 blob 的 **CloudBlockBlob** 类新实例：

CloudBlockBlob blob = container.GetBlockBlobReference("records.json");

6.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

CloudBlobClient blobClient = account.CreateCloudBlobClient();

CloudBlobContainer container = blobClient.GetContainerReference("drop");

CloudBlockBlob blob = container.GetBlockBlobReference("records.json");

}

#### 任务 4：下载一个 blob

1.  添加以下代码行，以使用 **CloudBlockBlob.DownloadTextAsync** 方法以异步方式下载引用的 blob 内容，并将结果存储在名为 *content* 的字符串变量中：

string content = await blob.DownloadTextAsync();

2.  添加以下代码行，以通过使用 **OkObjectResult** 类构造函数返回 *content* 变量的值：

return new OkObjectResult(content);

3.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

CloudBlobClient blobClient = account.CreateCloudBlobClient();

CloudBlobContainer container = blobClient.GetContainerReference("drop");

CloudBlockBlob blob = container.GetBlockBlobReference("records.json");

string content = await blob.DownloadTextAsync();

return new OkObjectResult(content);

}

4.  选择“**保存并运行**”以保存脚本并执行函数的测试执行。

5.  观察“**测试**”窗格中的“**输出**”文本框。你现在应该看到**存储帐户**中存储的 **$/drop/records.json** blob 内容。

#### 任务 5：创建共享访问签名 (SAS)

1.  **删除**以下代码行：

string content = await blob.DownloadTextAsync();

return new OkObjectResult(content);

2.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

CloudBlobClient blobClient = account.CreateCloudBlobClient();

CloudBlobContainer container = blobClient.GetContainerReference("drop");

CloudBlockBlob blob = container.GetBlockBlobReference("records.json");

}

3.  添加以下代码行，以使用以下设置创建一个新的 **SharedAccessPolicy** 类实例：
    
      - **权限**：读取
    
      - **服务范围**：Blob
    
      - **资源类型**：Object
    
      - **到期时间**：2 小时
    
      - **协议:** 仅 HTTPS

SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy()

{

Permissions = SharedAccessAccountPermissions.Read,

Services = SharedAccessAccountServices.Blob,

ResourceTypes = SharedAccessAccountResourceTypes.Object,

SharedAccessExpiryTime = DateTime.UtcNow.AddHours(2),

Protocols = SharedAccessProtocol.HttpsOnly

};

4.  添加以下代码行以使用 **CloudStorageAccount.GetSharedAcessSignature** 方法通过使用提供的策略生成新的 **共享访问签名 (SAS)** 令牌，然后将结果存储在名为 *sasToken* 的字符串变量中：

string sasToken = account.GetSharedAccessSignature(policy);

5.  添加以下代码行以连接 **CloudBlockBlob.Uri** 属性的值和 *sasToken* 字符串变量，并将结果储存在名为 *secureBlobUrl* 的新变量中：

string secureBlobUrl = $"{blob.Uri}{sasToken}";

6.  添加以下代码行，以通过使用 **OkObjectResult** 类构造函数返回 *secureBlobUrl* 变量的值：

return new OkObjectResult(secureBlobUrl);

7.  **Run** 方法现在应该类似于：

using System.Net;

using Microsoft.AspNetCore.Mvc;

using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

public static async Task\<IActionResult\> Run(HttpRequest req)

{

string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");

CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

CloudBlobClient blobClient = account.CreateCloudBlobClient();

CloudBlobContainer container = blobClient.GetContainerReference("drop");

CloudBlockBlob blob = container.GetBlockBlobReference("records.json");

SharedAccessAccountPolicy policy = new SharedAccessAccountPolicy()

{

Permissions = SharedAccessAccountPermissions.Read,

Services = SharedAccessAccountServices.Blob,

ResourceTypes = SharedAccessAccountResourceTypes.Object,

SharedAccessExpiryTime = DateTime.UtcNow.AddHours(2),

Protocols = SharedAccessProtocol.HttpsOnly

};

string sasToken = account.GetSharedAccessSignature(policy);

string secureBlobUrl = $"{blob.Uri}{sasToken}";

return new OkObjectResult(secureBlobUrl);

}

8.  选择“**保存并运行**”以保存脚本并执行函数的测试执行。

9.  观察“**测试**”窗格中的“**输出**”文本框。你现在应看到可用于访问安全 blob 的唯一 **安全 URL**。记录此 **URL**，稍后将在本实验室的下一个步骤中用到。

10. 在任务栏上，右键选择 **Microsoft Edge** 图标，然后选择“**新窗口**”。

11. 在新的浏览器窗口中，导航到你复制的 **安全****URL**。

12. 你现在应该看到 blob 的 **JSON** 内容。关闭显示 **JSON** 内容的浏览器窗口。

13. 返回 **Azure 门户**浏览器窗口。

#### 回顾

在本练习中，你使用了 C\# 代码安全访问存储帐户、下载 blob 内容并生成可用于在另一个客户端上安全访问 blob 的 SAS 令牌。

### 练习 5：清理订阅 

#### 任务 1：打开 Azure Cloud Shell 并列出资源组

1.  在 Azure 门户的顶部导航栏中，选择 **Cloud Shell** 图标打开一个新的 Shell 实例。

2.  在门户底部的 **Cloud Shell** 命令提示符中，输入以下命令，然后按 Enter 键列出订阅中的所有资源组：

az group list

3.  在提示符中，输入以下命令，然后按 Enter 键查看删除资源组的可能命令列表：

az group delete --help

#### 任务 2：删除资源组

1.  在提示符中，输入以下命令，然后按 Enter 键删除 **SecureFunction** 资源组：

az group delete --name SecureFunction --no-wait --yes

2.  关闭门户底部的“**Cloud Shell**”窗格。

#### 任务 3：关闭活动应用程序

> 关闭当前正在运行的 **Microsoft Edge** 应用程序。

#### 回顾

在本练习中，你通过移除本实验室中使用过的 **资源组** 来清理订阅。
