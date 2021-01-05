﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class partsPutter : MonoBehaviour
{
    //ステージ
    private Queue<GameObject> q;
    public GameObject rock;
    public GameObject grass;
    public GameObject tree;
    public int setStones;
    public int setGrasses;
    public int setTrees;
    private List<(double, double)> zahyos;
    private List<(double, double)> ground;
    public float fallY = 0;
    private float thetaX;
    private float thetaY;
    private float thetaZ;
    private Quaternion RandomQ;

    //ステージ生成時に呼び出されて、与えられたオブジェクトの子供になる石,木を配置する。削除はstage削除の責任
    public void Init(Transform obj,bool isCenter)
    {
        if (isCenter)
        {
            makeStones(obj);
        }

        makeGroundParts(obj,grass,setGrasses);
        makeGroundParts( obj, tree, setTrees);
    }

    void makeStones(Transform obj)
    {
        zahyos = new List<(double, double)> { (20.58754, 4.899223), (-1.300034, 26.98899), (25.4631, 22.99121), (22.27526, 11.62082), (24.06891, 4.136384), (22.29364, 5.241), (-5.420418, 32.45923), (27.26359, 28.96642), (29.2343, 31.25826), (25.18124, 35.939), (27.20792, 37.5463), (24.96747, 34.69944), (24.17019, 0.424251), (-27.73185, 33.29372), (24.56035, 28.46081), (58.68784, 32.37126), (27.19544, 44.13688), (6.232483, -6.742218), (25.60895, 26.22949), (26.07592, 0.6658347), (-7.637594, 3.712394), (-0.9335202, 12.75962), (24.71105, 20.87655), (25.93769, 20.6289), (20.8768, 13.646), (27.76908, 39.93235), (18.89862, 7.735958), (23.98905, 21.92479), (18.17096, -2.109088), (-2.921702, 9.209377), (14.92959, -1.431473), (23.23813, 10.27244), (26.76594, 35.96994), (19.22691, -2.423832), (23.09871, 4.855981), (57.48532, 32.11467), (26.44571, 26.07697), (28.12936, 39.043), (28.24126, 35.28059), (23.93743, 2.5776), (21.66018, 2.206057), (22.95036, 15.0027), (-4.07151, 34.25863), (-3.562027, 9.891973), (21.1118, 8.940252), (26.30535, 32.00114), (-2.467232, 46.49004), (25.12399, 47.11555), (40.20104, -5.314857), (24.03579, 48.85928), (24.98085, 1.039288), (21.16641, 12.87415), (29.21794, 44.67566), (21.56272, 11.98606), (23.15817, 28.15094), (28.52965, 44.85542), (-4.46476, 39.53558), (-5.796703, 38.99342), (22.26766, 18.9917), (25.62663, 41.86574), (23.32095, 8.342324), (25.85692, 47.08062), (24.50037, 43.23051), (22.63346, 28.45095), (2.893835, -6.788696), (23.57012, 25.95738), (23.53944, 16.29585), (20.26062, 15.22272), (-1.343429, 25.85093), (28.83502, 37.14653), (46.79374, -8.804853), (48.38651, -4.455073), (25.99551, 27.14751), (24.90052, 24.9243), (26.34079, 22.92611), (23.17289, 21.26926), (24.39015, 23.93001), (52.09583, 8.221446), (28.43036, 43.32614), (26.66052, -1.957039), (-6.888487, 6.256384), (-28.29808, 0.7101668), (67.37304, 30.51726), (25.42059, 24.16504), (24.93002, -6.248713), (25.91602, 30.9848), (-2.791241, 32.66457), (27.35268, 34.93699), (22.4637, -6.338289), (23.42976, -5.40807), (-0.7158461, 4.121839), (24.6297, 4.50343), (22.80116, 3.192353), (-6.131291, 24.0123), (21.08702, 6.946421), (26.76918, 1.519583), (23.79379, 5.747095), (-11.9929, 0.9399627), (25.64685, 7.02883), (26.30328, 44.12958), (28.46365, 40.47895), (28.56829, 44.08029), (26.31039, 40.3158), (23.20807, 14.29032), (-3.633183, 47.00024), (25.17312, 21.18013), (24.48292, 9.188571), (26.79309, 31.1631), (25.15525, 27.19114), (24.82041, 48.18209), (23.35556, 24.50354), (22.9499, 18.11518), (20.09012, 14.3208), (30.54623, 36.92138), (-3.303032, 32.64449), (23.53469, 26.96034), (25.49184, 31.69675), (21.45713, 7.946225), (77.57928, 30.10604), (27.55297, 41.56841), (24.3514, 1.87071), (29.19466, -4.518233), (23.18219, 2.289002), (24.12162, 46.28661), (27.34155, 47.04743), (-15.65102, 9.161039), (26.1499, 28.25648), (23.65129, 18.34499), (29.28656, 41.54707), (59.57012, 31.90037), (29.715, 34.01831), (21.11337, 17.00912), (22.09952, 16.92767), (27.72983, 27.59694), (38.27078, -2.794826), (30.09599, 35.04238), (24.8049, 21.91064), (22.71412, 5.966404), (24.51536, 4.952455), (28.01943, 28.57106), (21.99448, 9.664961), (21.20403, 4.383267), (22.11807, 23.80465), (25.63393, 25.4942), (11.22991, -6.999636), (26.18825, 34.25571), (20.29635, 13.00534), (28.80985, 39.63996), (23.58403, 46.83986), (21.68937, 6.330952), (25.67721, 35.00619), (26.64492, 46.79305), (27.27475, 24.71307), (-3.834361, 2.066821), (29.70628, 42.82318), (27.7232, -1.301191), (67.04132, 48.52235), (-3.303042, 15.64463), (22.35121, 4.281872), (26.0248, 35.93975), (-4.324194, 7.712689), (23.79808, 20.2054), (25.97776, 43.12687), (22.34825, 2.387839), (28.87385, 32.03083), (23.11281, 3.984022), (24.15245, 6.756403), (70.6023, 9.774389), (-1.180485, 29.38979), (20.25218, 6.471352), (24.01909, 25.32676), (26.77621, 43.30096), (31.93551, -3.340487), (22.19813, 12.79796), (23.96395, 10.64237), (30.63197, 39.45424), (26.41566, 39.17606), (25.21747, 6.076411), (-3.56268, 6.725879), (29.32318, 40.5431), (25.9937, 21.95524), (29.23601, 45.49445), (28.23175, 37.57832), (29.29035, 34.93649), (19.86959, 18.28758), (25.1827, 8.92956), (26.45423, 5.834147), (20.54642, 18.51673), (53.77513, 8.868602), (29.92561, 44.17778), (18.45972, 57.95644), (23.52541, 7.43808), (20.85415, 10.16177), (25.47545, 40.65099), (21.40824, 10.77025), (23.03723, 11.28494), (23.79736, 27.815), (26.8558, 27.20062), (26.74404, 48.46244), (28.68413, 28.46775), (25.12879, 43.29822), (30.30256, 38.72404), (23.79168, 11.63362), (-5.218427, 22.68094), (26.50588, 46.04169), (28.03459, 46.95277), (15.45015, -4.284397), (22.43252, 8.548656), (25.21868, 7.739078), (25.22603, -2.402367), (-4.303038, 45.64449), (29.25068, 43.63261), (26.26331, 6.94091), (28.40996, 53.38269), (16.61631, -8.960774), (25.7993, 45.97944), (23.97427, 22.70447), (21.72419, 3.048187), (25.95033, 29.12712), (40.3512, -4.95016), (27.02357, 29.43869), (27.28093, 45.33003), (20.05225, 9.876008), (20.92711, 14.81514), (21.65887, 14.80218), (24.0134, 19.31466), (20.76186, 8.156029), (51.43797, 5.782012), (21.95965, 15.82245), (27.86531, 46.05817), (21.8314, 18.10567), (34.94397, -6.393091), (23.84732, 47.95094), (24.32243, 47.27776), (25.86021, 5.864634), (20.96453, 5.852348), (24.23549, 34.59862), (71.52106, 11.18662), (28.9524, -4.245251), (28.44517, 45.70953), (22.94704, 16.9547), (24.1393, 26.73884), (24.95903, 6.93206), (29.13166, 36.24245), (24.49069, 5.868026), (24.08212, 7.868305), (49.64985, -4.426255), (27.60957, 48.51358), (25.34243, 3.5803), (25.27917, 42.5155), (23.57983, 1.516882), (27.04033, 39.86245), (24.72838, 23.04674), (28.761, 46.82301), (24.85054, 46.22387), (20.79684, 12.05629), (20.83662, 13.92264), (29.48739, 32.59087), (30.41504, 42.56228), (28.4562, 29.58204), (79.05052, 49.02008), (24.4381, 27.39726), (26.39044, 25.0088), (27.77381, 29.78988), (20.51208, 17.5914), (21.12154, 2.931683), (22.07804, 20.46343), (29.26471, 47.45556), (15.63818, -3.556688), (-1.238152, 44.05957), (23.58096, 23.77903), (22.6499, 23.22086), (27.06764, 34.16778), (54.06565, 6.451988), (29.62693, 38.90468), (-1.604121, 28.06461), (22.40614, 10.63753) };
        int leng = 277;
        for (int i = 0; i < setStones; i++)
        {
            var (a, b) = zahyos[Random.Range(0, leng)];

            thetaX = Random.Range(-180f,180f);
            thetaY = Random.Range(-180f,180f);
            thetaZ = Random.Range(-180f,180f);
            RandomQ = Quaternion.Euler(thetaX,thetaY,thetaZ);

            Instantiate(rock, new Vector3((float)a, fallY, (float)b)+obj.localPosition, RandomQ).transform.parent = obj;
        }
    }
    
    //地上の物体を生成するやつ。setObjがオブジェクト、setNumが設置する個数。
    void makeGroundParts( Transform obj,GameObject setObj,int setNum)
    {
        ground = new List<(double, double)> { (45.01919, 13.96026), (47.96863, 10.99967), (29.47169, 9.944052), (36.37767, 2.922089), (12.00573, 29.00301), (13.19244, 29.06791), (0.9999806, 20.00492), (49.12238, 29.01264), (8.913065, 47.9621), (6.700377, 24.93595), (38.57303, 21.89351), (40.73598, 18.80081), (38.12259, 39.93804), (46.95525, 39.97743), (34.83863, 29.05747), (38.98549, 31.97863), (43.72847, 14.07473), (14.11556, 48.59193), (37.81494, 4.372528), (11.69533, 23.75284), (47.95365, 12.99336), (36.08168, 25.08246), (36.77013, 18.82947), (18.06748, 2.035887), (12.59119, 6.291585), (29.76208, 5.223201), (8.192534, 1.89987), (4.723432, 14.98423), (11.67152, 27.13047), (14.44721, 17.89558), (41.01837, 20.94269), (32.55668, 4.710207), (16.88347, 7.188868), (38.99304, 33.98274), (14.78522, 29.03897), (7.013394, 31.0029), (41.52759, 42.36227), (10.56377, 6.53244), (16.72787, 28.9766), (5.098553, 38.13406), (32.46453, 45.81306), (42.52909, 44.15627), (30.30558, 14.11335), (33.69704, 12.95351), (15.51947, 22.1061), (13.97015, 35.96702), (4.911147, 32.0624), (16.99829, 45.02559), (39.99615, 22.98463), (47.04729, 26.91314), (7.823292, 31.98246), (40.00308, 17.97407), (7.942022, 29.01561), (13.82241, 26.79363), (31.96533, 15.89583), (35.98346, 48.6095), (37.03944, 33.99775), (5.520566, 16.93501), (1.031954, 35.09692), (34.68314, 10.07378), (37.14838, 31.07317), (4.008883, 33.98721), (16.97661, 27.99348), (12.02628, 15.47953), (13.64673, 13.71518), (4.48391, 47.58073), (7.623147, 26.31286), (5.020451, 45.99294), (4.377267, 19.28611), (12.88704, 17.99577), (37.69215, 30.11787), (1.135857, 14.86828), (47.95807, 12.00817), (18.97835, 33.92393), (14.70353, 40.20826), (49.11419, 0.9407794), (4.030988, 40.00871), (35.3667, 0.5795394), (28.54828, 14.10546), (8.952996, 40.76831), (17.95278, 44.99828), (3.712933, 14.01969), (2.112813, 2.310287), (36.96852, 42.39118), (43.97303, 6.675859), (36.25726, 22.93583), (2.07267, 14.06023), (48.97407, 30.16281), (16.40517, 16.86563), (12.99942, 27.99901), (3.816991, 17.95339), (1.130764, 46.0357), (3.989272, 17.09575), (0.8697522, 11.94633), (43.03347, 18.09245), (14.14453, 19.35148), (42.05085, 30.03501), (29.04095, 6.966957), (31.19575, 22.18799), (4.617064, 35.11848), (48.98601, 9.929587), (13.57056, 16.28404), (18.467, 38.12785), (0.5863323, 35.8839), (34.90845, 2.774346), (43.01768, 24.99785), (39.23835, 19.10545), (33.99711, 47.012), (2.753226, 28.28131), (7.973303, 46.98074), (47.98346, 27.98715), (11.24224, 40.95966), (1.952853, 43.82543), (36.73537, 27.09848), (2.186011, 26.09868), (20.04999, 35.01435), (18.82372, 47.77304), (5.452166, 43.82486), (16.00129, 43.02401), (41.73736, 2.066913), (18.99965, 42.04091), (14.40309, 14.7714), (39.16693, 27.06322), (43.97342, 17.3139), (42.20248, 31.06561), (3.997239, 43.01394), (8.353468, 30.94532), (12.99496, 37.99564), (13.98953, 32.03982), (15.56181, 11.97561), (19.21022, 31.93773), (29.9259, 13.03938), (39.04227, 18.02147), (12.5948, 41.87902), (32.01868, 25.97992), (48.17659, 9.840435), (34.88376, 28.02455), (42.53853, 35.79766), (10.03479, 15.97027), (34.27317, 43.89211), (11.56458, 38.8096), (34.99456, 6.980391), (12.95305, 18.89375), (1.026957, 7.976487), (36.82953, 7.639636), (47.9689, 35.05278), (7.144944, 13.85727), (37.24064, 49.4343), (3.319785, 15.57091), (13.72647, 25.77248), (2.986693, 20.95643), (47.02677, 35.96913), (36.93888, 40.9798), (37.30823, 2.948835), (1.796278, 40.15292), (4.950492, 49.01303), (41.0209, 17.04944), (38.85736, 45.18424), (43.22898, 30.05469), (32.00444, 27.94898), (33.02773, 43.01971), (33.66976, 41.94543), (38.96963, 12.70465), (2.316547, 17.91137), (40.55928, 42.90324), (34.03256, 39.98729), (6.144821, 14.78405), (1.021643, 22.9986), (28.99742, 16.94493), (14.5586, 0.6088015), (18.9569, 29.9474), (12.92604, 44.09878), (5.098721, 12.28447), (48.96862, 45.97179), (2.297864, 5.052189), (6.10087, 29.00707), (36.07169, 7.962906), (12.24532, 7.978476), (35.94749, 16.9473), (5.278582, 26.1876), (2.872476, 14.04062), (17.15252, 26.46839), (0.9743743, 40.11448), (1.993845, 27.97986), (3.997938, 31.06662), (47.24759, 6.733481), (16.10823, 12.93225), (14.99873, 8.450155), (16.86114, 41.05168), (48.25451, 2.075943), (40.00305, 40.03441), (0.6132813, 4.956284), (35.05817, 30.16056), (46.01102, 9.980014), (41.02133, 41.01615), (33.55959, 43.83092), (49.17282, 15.81369), (48.9456, 40.00291), (16.98267, 37.94151), (34.78955, 42.85601), (36.58036, 37.80724), (6.456884, 47.90209), (14.67268, 24.77928), (49.00053, 23.97823), (40.35318, 46.03323), (32.43304, 11.20689), (8.19582, 45.60535), (35.87836, 43.28027), (45.98338, 20.98236), (42.33933, 3.906417), (39.93446, 49.01361), (15.27968, 14.76986), (16.55688, 37.25241), (14.79957, 15.62162), (34.32732, 16.0864), (17.01902, 20.99733), (18.7858, 26.80909), (10.60405, 12.93808), (32.02872, 1.919308), (7.169788, 48.04443), (1.453288, 5.104308), (8.903923, 8.026443), (8.327455, 35.80318), (6.039084, 45.03375), (2.436288, 44.55127), (12.07831, 17.05272), (1.22314, 3.972434), (35.63661, 46.02838), (6.075948, 2.721291), (35.04209, 20.91103), (31.80426, 8.278811), (3.560588, 27.93863), (14.85658, 11.95803), (21.0056, 30.98916), (4.313594, 35.97043), (6.392887, 35.3285), (5.163535, 28.8456), (36.49717, 28.17648), (15.71306, 15.93082), (42.96381, 23.94761), (45.64244, 31.94201), (5.242324, 18.18492), (30.97375, 1.040224), (43.61682, 45.0541), (15.36302, 3.085989), (7.024775, 3.973833), (8.171832, 24.71983), (44.35579, 21.85921), (40.17207, 22.10572), (6.671546, 27.07296), (4.562439, 26.24999), (18.99196, 35.99697), (1.839248, 29.00203), (34.55185, 1.074506), (43.37581, 33.06458), (3.739365, 5.220565), (3.847991, 3.315584), (3.424111, 11.78865), (33.03325, 10.09381), (37.9973, 24.00806), (5.696198, 28.07475), (8.880186, 18.85506), (14.34532, 38.17854), (43.41205, 4.98251), (7.5279, 41.8474), (3.774311, 35.08089), (33.88434, 5.482491), (6.008471, 38.98931), (20.47959, 37.87064), (47.00564, 22.932), (18.94684, 44.90327), (8.009144, 22.04308), (43.08163, 26.01637), (34.98343, 25.9662), (30.09887, 7.98809), (11.02691, 11.05712), (39.77974, 29.08036), (7.117812, 28.01128), (46.04078, 45.32531), (16.42488, 23.99502), (36.52588, 11.96867), (40.97414, 25.96461), (11.29649, 29.01411), (29.83316, 3.861416), (4.057489, 8.003191), (7.017747, 35.93294), (14.00229, 45.98967), (18.25933, 48.64737), (10.07067, 31.161), (1.496733, 37.78138), (38.98944, 5.199735), (15.0059, 47.741), (47.04855, 37.49881), (40.02604, 36.99297), (11.88578, 6.770599), (35.99496, 14.91161), (34.85333, 17.73374), (7.678257, 2.982593), (6.000648, 33.01539), (32.02211, 27.09833), (4.950267, 38.98581), (8.9535, 38.26686), (42.26347, 8.983933), (2.067407, 36.9418), (9.259366, 12.83893), (3.998189, 1.957898), (32.77186, 22.0818), (33.4922, 13.98833), (48.97486, 20.95845), (43.00862, 8.980184), (48.21585, 44.84841), (15.52145, 31.73075), (32.7356, 23.11343), (45.24745, 46.48129), (38.97045, 48.05662), (34.13301, 25.98216), (35.27152, 19.94577), (40.28219, 3.006427), (14.89112, 37.12505), (18.0854, 33.09381), (19.27631, 49.10606), (4.261148, 28.05275), (36.93854, 13.04856), (46.99049, 9.053635), (40.03302, 24.95011), (42.89685, 14.39633), (11.42064, 14.88422), (4.977509, 39.96964), (36.11957, 46.98964), (46.7415, 10.89319), (44.1382, 24.9677), (17.05494, 38.94703), (1.641131, 25.17113), (47.15174, 30.09979), (5.056085, 21.90924), (41.52166, 26.87585), (39.29611, 34.86358), (8.316786, 6.093114), (2.750279, 6.061478), (15.62592, 18.93298), (30.99717, 20.01621), (0.9970549, 13.97481), (14.02835, 7.989828), (35.4554, 32.02443), (42.03018, 45.03525), (31.48763, 13.84674), (9.978835, 5.525884), (43.80277, 3.170464), (40.79792, 15.10503), (35.73618, 22.26332), (10.98429, 3.761423), (5.961419, 23.96148), (7.804518, 43.21871), (11.53714, 44.76939), (12.17775, 25.99301), (41.88654, 4.906621), (3.703404, 48.13004), (45.06788, 48.04605), (33.0256, 1.612542), (38.06842, 39.01962), (41.00959, 7.931831), (48.3138, 19.99102), (41.49309, 14.9038), (10.94436, 27.00233), (31.97148, 16.96128), (43.98976, 16.08193), (47.41695, 44.12919), (46.09412, 4.100965), (32.67567, 14.03485), (44.1504, 32.08496), (19.10069, 37.06736), (46.54543, 43.67585), (21.21776, 38.04621), (8.00045, 6.940995), (4.040534, 32.03708), (1.656348, 22.05959), (44.43657, 46.98786), (38.56293, 4.197401), (46.9858, 28.02293), (33.70004, 33.9113), (19.02777, 31.04024), (19.6699, 32.92888), (29.5642, 13.90993), (38.88817, 14.86606), (39.9854, 20.05946), (34.38148, 36.23985), (5.215787, 20.15467), (5.458986, 14.29191), (5.026811, 42.04028), (30.0512, 1.762012), (0.4549725, 31.18028), (37.32792, 1.675227), (34.55048, 35.12283), (14.55544, 44.75838), (14.82985, 24.01963), (31.72409, 47.93548), (42.98119, 16.92043), (44.9215, 31.85599), (35.94034, 45.10503), (40.45377, 29.73923), (34.54994, 5.109079), (12.88936, 25.86898), (12.46427, 49.63542), (17.58933, 21.80272), (7.551943, 24.36689), (39.98939, 34.65572), (30.9359, 8.015326), (5.936803, 33.99793), (41.66925, 29.00178), (31.44907, 9.940434), (46.9347, 13.0124), (39.80843, 15.00014), (35.09474, 42.0332), (42.18794, 14.70633), (16.76455, 41.94608), (45.96621, 48.01019), (4.54161, 18.05404), (8.799724, 47.1943), (2.040822, 10.03493), (13.93439, 23.10697), (12.93999, 3.007015), (7.423654, 19.27528), (38.11091, 37.13411), (39.51744, 1.207983), (45.09556, 33.91381), (42.99318, 48.34265), (43.83942, 30.99231), (36.94703, 33.04345), (0.7777684, 47.03394), (14.99375, 5.957888), (17.00409, 8.864351), (43.26781, 4.162614), (8.184921, 33.89566), (41.75485, 23.06289), (1.034361, 29.00461), (16.68329, 25.14971), (11.03905, 9.845493), (36.06983, 6.81386), (3.072855, 47.21717), (42.0032, 12.65003), (39.98913, 23.99499), (14.9528, 10.06442), (9.698867, 25.31374), (8.023408, 9.970231), (11.42319, 35.95192), (40.37399, 39.00642), (33.54427, 7.999629), (5.335528, 36.23305), (39.89231, 10.37341), (13.21331, 43.16682), (5.438114, 34.79422), (10.75616, 26.19805), (36.07118, 36.93216), (38.01577, 13.97586), (11.64476, 24.59261), (38.9725, 16.05743), (45.82003, 30.89964), (40.99352, 6.918541), (36.02427, 36.01617), (42.9683, 21.00318), (35.67801, 28.956), (11.45175, 25.93362), (47.1002, 3.587825), (10.99473, 13.99205), (46.57382, 8.13327), (33.9477, 28.9763), (29.63548, 21.01508), (34.87077, 4.342752), (9.439542, 41.9207), (41.66458, 49.00041), (37.16215, 5.676119), (3.18536, 31.01016), (32.97767, 45.00435), (13.69282, 35.10809), (46.37377, 26.66499), (39.93374, 3.828565), (8.392096, 12.91068), (21.32999, 35.95203), (49.26923, 4.197281), (3.977557, 41.01797), (8.952751, 7.107113), (0.9913046, 11.11164), (17.96709, 33.97723), (47.07904, 45.92572), (4.593209, 44.01647), (37.0207, 17.03895), (6.522955, 5.979963), (9.990068, 2.041031), (40.65066, 3.920089), (47.2564, 44.88777), (14.97409, 12.73617), (10.08397, 38.95572), (46.63362, 39.13371), (20.94309, 29.11125), (47.79633, 42.21618), (10.9494, 40.04816), (18.90528, 33.0537), (32.66312, 47.01632), (2.907824, 0.3046026), (36.34104, 31.86546), (15.13128, 3.87447), (43.40637, 21.93634), (4.047406, 46.0155), (11.22493, 17.6533), (41.01684, 12.08686), (21.02324, 34.05122), (27.93758, 12.98702), (10.33195, 42.34443), (12.07385, 30.97339), (7.157191, 22.36461), (7.622022, 16.79578), (43.30989, 33.91205), (34.84446, 40.79591), (16.67812, 6.203147), (46.32962, 35.68265), (44.16135, 5.041695), (19.03817, 43.95445), (34.48234, 22.73557), (34.94943, 45.23348), (1.022964, 1.970122), (12.30589, 1.04581), (47.61584, 41.33908), (32.92014, 29.91873), (8.94914, 14.04901), (45.31746, 32.81451), (34.48112, 7.918967), (40.602, 10.13846), (11.33556, 42.02323), (13.68099, 15.25541), (39.19248, 28.04917), (12.87314, 46.96198), (35.54947, 34.93397), (38.04758, 9.05001), (32.02432, 13.09221), (9.720392, 17.14802), (38.36118, 2.038702), (9.947285, 46.9472), (39.09727, 47.09318), (19.00675, 25.09957), (17.88698, 35.87299), (46.06227, 2.075115), (3.451259, 4.014661), (30.88148, 11.3918), (38.33905, 27.79459), (34.5166, 10.83971), (5.341419, 3.951277), (32.09808, 1.052228), (17.55754, 36.71348), (40.89769, 23.01717), (48.57684, 31.83521), (4.18419, 37.8709), (7.47203, 34.06839), (31.44976, 3.147586), (48.85027, 48.03689), (44.74847, 19.54147), (1.446183, 29.80257), (6.672696, 23.96099), (41.79494, 22.08404), (42.96538, 41.01656), (15.39532, 41.80779), (12.27985, 34.06882), (13.40067, 48.89849), (10.77975, 30.17565), (8.577692, 26.8864), (32.74951, 27.22561), (17.01171, 0.6232509), (5.972339, 24.91506), (35.10246, 14.94046), (46.05128, 43.10667), (36.98949, 17.9899), (6.935531, 32.08382), (13.28961, 5.845532), (37.34364, 15.00832), (28.9446, 18.00689), (42.65334, 5.124355), (9.949111, 38.0198), (1.977839, 0.7346134), (13.01125, 23.95238), (39.93993, 36.07029), (4.004166, 38.98584), (5.013075, 34.02668), (12.44503, 27.00253), (5.993189, 7.058557), (42.82365, 45.10242), (4.877162, 22.88838), (13.98921, 8.991276), (7.400261, 36.72471), (34.32816, 11.87018), (0.9332916, 37.04047), (38.51116, 26.74459), (5.899144, 11.98387), (14.09854, 11.10479), (12.92245, 31.07504), (10.04908, 10.96778), (48.18865, 32.78135), (15.33123, 15.22271), (12.97825, 10.22901), (48.01039, 26.05404), (39.2509, 4.051461), (15.06646, 21.43969), (35.19092, 47.9948), (36.44517, 35.13391), (44.91822, 30.36362), (8.321813, 43.95603), (17.12191, 35.0188), (43.51914, 9.918057), (6.401217, 13.60479), (18.34495, 31.64814), (33.0284, 29.01569), (37.31678, 28.7173), (11.8869, 9.225494), (10.90619, 22.24615), (2.968107, 18.94342), (2.465148, 35.81369), (40.03435, 45.0075), (44.46365, 41.99715), (15.04299, 43.02863), (42.98135, 0.9881111), (44.66494, 23.77156), (1.002712, 23.91706), (41.2891, 29.89841), (45.79643, 4.968267), (37.23328, 31.96057), (1.050027, 16.05203), (40.76386, 41.99387), (14.04639, 42.96317), (17.46022, 46.03283), (39.95687, 41.97034), (39.44426, 37.75968), (38.08828, 15.52695), (41.4921, 3.870647), (13.95682, 22.0082), (37.95858, 17.03471), (9.02174, 33.78545), (46.23439, 2.892135), (40.81507, 9.206251), (33.55737, 16.22904), (37.0553, 20.04269), (29.32232, 10.96124), (36.36219, 14.01439), (16.99146, 8.001475), (37.84334, 21.95056), (0.9734102, 49.05259), (12.60662, 13.10379), (49.0021, 17.1465), (16.26411, 35.00239), (35.67561, 16.12633), (31.22789, 16.00431), (8.183396, 23.77638), (36.9817, 46.77864), (39.97955, 32.01841), (8.052279, 15.92934), (19.0336, 26.01293), (33.6353, 33.14001), (44.04052, 36.98009), (43.83331, 10.8612), (9.913921, 43.33738), (38.97037, 5.965894), (32.71894, 15.96798), (40.41379, 32.88229), (9.79026, 24.03086), (5.784997, 43.13486), (45.01203, 16.98547), (40.68914, 46.97782), (37.12133, 15.92964), (15.33013, 33.11333), (5.978855, 38.0239), (9.010324, 28.97988), (36.36742, 33.722), (46.88866, 12.31796), (46.84883, 23.89672), (12.13678, 17.89763), (45.01941, 37.98924), (15.58683, 25.70159), (35.78057, 33.00967), (16.04356, 29.91956), (36.39519, 4.457765), (48.59722, 6.966216), (6.441871, 4.828304), (5.217492, 15.79464), (18.17219, 27.30163), (7.838594, 4.101367), (14.99256, 17.05129), (45.67211, 5.929385), (44.73877, 26.09883), (35.76279, 12.05384), (15.45944, 34.89479), (40.95971, 28.11185), (40.57711, 30.54597), (19.17763, 40.97001), (19.83829, 43.63707), (40.86298, 4.930487), (46.38536, 30.1259), (37.01808, 40.05471), (11.01979, 48.9362), (29.79715, 18.04179), (48.41143, 38.90894), (34.61055, 38.24572), (40.24413, 44.12736), (37.38335, 34.86357), (44.86862, 11.99445), (30.42542, 20.73128), (33.45806, 47.85364), (8.566817, 4.360091), (3.949934, 48.92322) };
        int leng = 705;
        for (int i = 0; i < setNum; i++)
        {
            var (a, b) = ground[Random.Range(0, leng)];

            Instantiate(setObj, new Vector3((float)a, 0,  (float)b)+ obj.localPosition, Quaternion.identity).transform.parent = obj;
        }
    }

}
