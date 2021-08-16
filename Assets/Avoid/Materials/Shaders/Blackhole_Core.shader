// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/blackhole/Blackhole_Core"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_FresnelValue("Value", float) = 1
		_FresnelPower("Power", float) = 1
		_FresnelIntensity("Intensity", float) = 1.5
		_Color("Color", Color) = (0, 0, 0, 1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Name "Forward"
			Tags{"Lightmode" = "ForwardBase"}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			//#define UNITY_PASS_FORWARDBASE
			//#pragma multi_compile_fwd_fullshadows
			#pragma only_renderers d3d9 d3d11 glcore gles
			#pragma target 3.0

			float _FresnelValue;
			float _FresnelPower;
			float _FresnelIntensity;
			float4 _Color;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float4 vertex_Color : COLOR;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float4 worldPos : TEXCOORD0;
				float3 normalDir : TEXCOORD1;
				float4 vertex_Color : COLOR;
				UNITY_FOG_COORDS(1)
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex_Color = v.vertex_Color;
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.normalDir = UnityObjectToWorldNormal(v.vertex);   
				o.vertex = UnityObjectToClipPos(v.vertex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				i.normalDir = normalize(i.normalDir);
				float3 viewDir = normalize(i.normalDir);
				float3 normalDirection = i.normalDir;

				float3 emission	= (_Color.rgb + ((i.vertex_Color.rgb * pow(pow(1.0 - max(0, dot(normalDirection, viewDir)), _FresnelValue), _FresnelPower)) * _FresnelIntensity));

				float4 col = float4(emission, 1);		

				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
