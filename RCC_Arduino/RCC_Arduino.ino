#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

WiFiUDP Udp;

const char *APssid = "RCC";
const char *APpassword = "123rcc"; 
IPAddress APlocal_IP(192, 168, 4, 1);
IPAddress APgateway(192, 168, 4, 1);
IPAddress APsubnet(255, 255, 255, 0);
int ledPin = 5; // D1
int ledPin2 = 4; // D2


unsigned int localUdpPort = 4210;
char incomingPacket[255];
char replyPacket[] = "Hi there! Got the message :-)";
char comChar;


void setup() {
	Serial.begin(115200); 
	pinMode(ledPin, OUTPUT);
	digitalWrite(ledPin, LOW);
	pinMode(ledPin2, OUTPUT);
	digitalWrite(ledPin2, LOW);

	WiFi.mode(WIFI_AP_STA);

	Serial.println(WiFi.softAPConfig(APlocal_IP, APgateway, APsubnet) ? "OK" : "Failed!"); 
	Serial.print("Setting soft-AP ... ");
	Serial.println(WiFi.softAP(APssid, APpassword) ? "OK" : "Failed!");
	Serial.print("Soft-AP IP address = ");
	Serial.println(WiFi.softAPIP()); 
	Serial.println();
	Serial.print("Station connected, IP address: ");
	Serial.println(WiFi.localIP());
	Serial.printf("Signal Strength: %d dBm\n", WiFi.RSSI());

	Serial.println("begin UDP port");
	Udp.begin(localUdpPort);
	Serial.print("local UDP port: ");
	Serial.println(localUdpPort);


}

void loop() {

	int packetSize = Udp.parsePacket();
	if (packetSize)
	{
		
		int len = Udp.read(incomingPacket, 255);
		if (len > 0)
		{
			incomingPacket[len] = 0;

			comChar = incomingPacket[0];
			switch (comChar) {
			case 'A':
				digitalWrite(ledPin2, LOW);
				digitalWrite(ledPin, HIGH);
				break;
			case 'D':
				digitalWrite(ledPin, LOW);
				digitalWrite(ledPin2, HIGH);
				break;
			default:
				digitalWrite(ledPin, LOW);
				digitalWrite(ledPin2, LOW);
				break;
			}
		}

	}

}
