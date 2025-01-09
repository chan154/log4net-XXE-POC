# Log4net XXE Demo (CVE-2018-1285)

This repository demonstrates a proof-of-concept exploit for [CVE-2018-1285](https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2018-1285), affecting **Apache log4net** prior to `v2.0.10`. It specifically shows how XML External Entity (XXE) injection can occur when parsing log4net configuration files.

> **Warning**  
> - This demo is for **educational and testing** purposes **only**.  
> - Do **not** use this against any system you do not own or have explicit permission to test.  
> - The provided example is intentionally **vulnerable** and should **never** be used in production.  
> - Upgrade to **log4net v2.0.10+** or later to mitigate this vulnerability.

---

## Overview

- **Vulnerability**: [CVE-2018-1285](https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2018-1285)  
- **Affected Component**: log4net versions before `2.0.10`  
- **Type of Exploit**: XML External Entity (XXE)  
- **Impact**: Potentially read arbitrary files from the filesystem or even conduct server-side request forgery (SSRF), depending on the XML parser settings and environment.

---

## Prerequisites

- **Visual Studio 2015** (though any version of Visual Studio that targets **.NET Framework 4** should work)  
- **log4net 1.2.10** (the vulnerable version)  
- A Windows machine (the demo references `C:/Windows/System32/drivers/etc/hosts`)

---

## Installation & Setup

1. **Clone** or **download** this repository.  
2. **Open the solution** (`Log4NetXXEDemo.sln`) in **Visual Studio 2015**.  
3. Right-click the **References** node in **Solution Explorer**, then **Add Reference...**.
   - Select **Browse** and add your **log4net.dll (v1.2.10)** file.  
4. In **Solution Explorer**, select `log4net.config`. In its **Properties**, set **Copy to Output Directory** to **Copy if newer** (or **Copy always**).

---

## How to Run

1. Build the solution in Debug or Release mode.
2. Run the console app using Ctrl + F5 (Start Without Debugging) or from a Command Prompt.
3. In the console output, you should see:
![image](https://github.com/user-attachments/assets/1a0d1fb1-90a3-49a7-babc-70d28549eb8c)

---

## Mitigation
- Upgrade to log4net 2.0.10+ which disables XML external entities by default.
- Do not accept or load untrusted log4net configuration files.
- If you must parse external XML, ensure you set safe parser settings (e.g., disable DtdProcessing or set XmlResolver = null).

---

## Troubleshooting

- - Console Closes Immediately: Make sure you run the app without debugging (Ctrl+F5) or include Console.ReadKey() so you can see the output.
- - Attribute Value Error: If you see XmlException: attribute values must not contain direct or indirect entity references to external entities, it means .NET’s XML parser is blocking the entity in an attribute. The above configuration places it in element content specifically to avoid that.
- - No XXE Expansion:
      - Confirm your log4net version is 1.2.10.
      - Ensure log4net.config is copied to the output directory.
      - Try referencing a different local file with simpler permissions (e.g., /path/test.txt).

---
## Disclaimer

This repository is provided for educational and proof-of-concept purposes only. Any unauthorized use of this code, or use against systems without explicit permission, is prohibited. By using this repository, you agree that you bear responsibility for any consequences.

Happy Testing!

---
