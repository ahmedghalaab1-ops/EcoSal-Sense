#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h> // تأكد من تثبيت مكتبة ArduinoJson من الـ Library Manager

// بيانات شبكة الـ Wi-Fi الخاصة بك
const char* ssid = "YOUR_WIFI_SSID";
const char* password = "YOUR_WIFI_PASSWORD";

// رابط الـ API الخاص بك (ضع آيباد جهاز الكمبيوتر الذي يعمل عليه السيرفر بدل localhost)
const char* serverUrl = "http://192.168.1.50:5000/api/soil/readings";

// تعريف أطراف الحساسات في الـ ESP32
const int soilMoisturePin = 34; // پین تناظري لحساس الرطوبة
const int tdsPin = 35;          // پین تناظري لحساس الـ TDS

void setup() {
  Serial.begin(115200);
  delay(1000);

  // الاتصال بالـ Wi-Fi
  WiFi.begin(ssid, password);
  Serial.print("Connecting to WiFi");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected!");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

void loop() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;

    // قراءة البيانات الخام من الحساسات
    int rawMoisture = analogRead(soilMoisturePin);
    int rawTds = analogRead(tdsPin);
    float voltage = (float)analogRead(32) * 3.3 / 4095.0; // مثال لقراءة الفولتية

    // تجهيز البيانات في صيغة JSON
    StaticJsonDocument<200> jsonDoc;
    jsonDoc["deviceId"] = "ESP32_ECOSAL_01";
    jsonDoc["soilMoistureRaw"] = rawMoisture;
    jsonDoc["tdsRaw"] = rawTds;
    jsonDoc["voltage"] = voltage;

    String requestBody;
    serializeJson(jsonDoc, requestBody);

    // بدء طلب الـ HTTP POST
    http.begin(serverUrl);
    http.addHeader("Content-Type", "application/json");

    int httpResponseCode = http.POST(requestBody);

    if (httpResponseCode > 0) {
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      String response = http.getString();
      Serial.println(response);
    } else {
      Serial.print("Error on sending POST: ");
      Serial.println(httpResponseCode);
    }

    http.end();
  } else {
    Serial.println("WiFi Disconnected");
  }

  // إرسال قراءة كل 30 ثانية
  delay(30000);
}