 Shader "Unlit/Cloth"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_DragDirection("DragDirection", Vector) = (0,0,0)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float3 _DragDirection;

			v2f vert (appdata v) 
			{
				float xdelayFactor = abs(v.vertex.y);
				const float PI = 3.14159;
				float radian_z =  _DragDirection.z / (2 * PI);
				float y_offset = abs(v.vertex.y) - cos(radian_z) * abs(v.vertex.y);
				float z_offset = sin(radian_z) * abs(v.vertex.y);
				
				float radian_x =  _DragDirection.x / (2 * PI);
				float y_offset_1 = abs(v.vertex.y) - cos(radian_x) * abs(v.vertex.y);
				float x_offset = sin(radian_x) * abs(v.vertex.y);

				// _DragDirection.w = 1;
				//float4 localPos = mul(unity_WorldToObject, _DragPoint);
				//float xdelayDir = localPos.x - v.vertex.x;
				
				// float xdelayFactor = abs(v.vertex.x);
				//v.vertex.x += (_DragDirection.x * xdelayFactor);  
				v.vertex.y += y_offset;
				v.vertex.y += y_offset_1;
				v.vertex.x += x_offset; 
				v.vertex.z += z_offset;

				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				return col;
			}
			ENDCG
		}
	}
}
