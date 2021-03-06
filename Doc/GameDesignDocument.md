# Tree Creator Game Design Document

## Key-Value 文档属性

作品工作标题：Tree Creator  
作品主标题：[Null]  
作品商业标题：[Null]

文档维护人： [LviatYi][lviatyiaddr]  
文档版本：1.00
文档附言：[Null]  

<!--
    TODO_LviatYi: 更新文档附言
-->

[What is Game Design Document?][gdd-wiki]

## Overview 概述

### Game Concept 游戏概念

Tree Creator(TC) 是一款 2D 策略养成类的游戏。玩家将扮演一棵潜力无限的大树的根系，在充满可能的泥土中探索、决策，最终成就一棵巨树的繁茂。

### Game Genre 游戏类型

TC 是一款回合制策略游戏 (Turn-Based Strategy,TBS)。TBS 是策略游戏的一种子类型，玩家在自己的回合中能够进行操纵，回合结束后将结算回合中玩家的决策。

### Setting 设定

森林是生命的摇篮。玩家扮演的树不仅是上帝创造森林的首次尝试，更是伟大的物质基础决定上层建筑的哲学实践，所以...如果过于丑陋，也不要沮丧。

至于人类？还没有呢。

## Gameplay 可玩性

### Action 玩家行为

玩家将操纵树根在土壤中进行探索或其他行为。

玩家将收集到以下元素：

- 水
- 石
  - 控制树叶的 G 通道
  - 允许树冠发展。
  - 允许树根发展。
- 粦
  - 控制树叶的 R 通道
  - 允许树冠发展。
  - 一些加分。
- 甲
  - 控制树叶的 B 通道
  - 允许树冠发展。
  - 促进果实生长。

<!-- 
    TODO_LviatYi:可依据生物学继续补充设定。
-->

- 特殊元素
  - 果核
    允许生长果实。
    果实可以交换为大量分数。
  - 小男孩 亚当
  地图上将生成一个活蹦乱跳小男孩。
  Warning: 这个不确定因素可能捡到有价值的物品，也可能导致你连根都不剩！
  - 宝石矿
  这种闪闪发光的物质据说可以换取大量分数...至少大家都这么说。
  但是为什么没有加分呢？一定是游戏出了bug...
  - 金坷垃
  植物界的咖啡因。
  上个文明轮回的精神与物质双重遗留文物。
  - 毒素
  击杀某些敌对目标后获得。
  - 其他神奇的 painted eggshell。

每回合玩家都可以花费行动点操纵一支子根进行如下操作：

- 探索
  - 向下伸展  
    当前操纵的树根将向下延伸一格。
  - 向左伸展  
    当前操纵的树根将向左延伸一格。
  - 向右伸展  
    当前操纵的树根将向右延伸一格。
  - 分支  
    当前操纵的树根将创造一格节点，允许从节点出发延伸出新的子树根。
- 部署
  部署将耗费一定的时间，在此阶段玩家将在一段时间内失去对这支树根的操纵。结束后将获得一些奖励。
  - 向下吸收
    当前操纵的树根将吸收下方一格的物质。
  - 向左吸收
    当前操纵的树根将吸收左方一格的物质。
  - 向右吸收
    当前操纵的树根将吸收右方一格的物质。
- 攻击
  攻击将耗费一定的时间，在此阶段玩家将在一段时间内失去对这支树根的操纵。
  - 绞杀
  消耗大量时间，可能失败。
  - 穿刺
  消耗一定时间与某资源点。
  - 毒杀
  消耗些许时间与特殊资源点。

### Objective 目标

- 视觉目标
  玩家的经济将直接反馈为地上植茎的发展。
  达到特定的要求地上植茎将出现不同的形态。
- 分数目标
  玩家的探索、经济、击杀行为都将获取分数。玩家需达到设定上的分数。
- 挑战目标
  在一定回合数后，将强制结束并计算分数。游戏中表现为冬季降临。

### Map 地图

主要场景为地表下的土壤，因此地图主要指地表下的瓦片组成。

地图由游戏随机生成。在不同的深度，不同的物质有着不同的刷新概率。同时也会刷新各种挑战或阻碍。

### Element 元素

#### Story 故事

不要啦，灵感被榨干啦！

#### Entity 实体

非生物实体将以瓦片的形式展示。

TODO_LviatYi:这部分的内容仍需后期更新完善。

##### 树

- 树根
- 树干
- 树枝
- 树叶
- 树果
- 树饰

##### 土壤

- 泥土
- 地下水
- 无机盐矿
- 宝石矿
- 果核
- 宝藏
- 其他可扩展

##### 生物

- 友好生物
  - 小男孩
- 中立生物
  - 蚂蚁
  - 飞鸟
- 敌对生物
  - 甲虫
  - 毒甲虫
  - Boss 沙虫 夏胡鲁

##### Character 角色

- 操纵角色
- 中立角色
- 敌对角色

### Gallery 艺术画廊

![CompletedTree](./assets/pic/CompletedTree.png "概念图-游戏后期玩家养成的巨树")
![Sapling](./assets/pic/Sapling.png "概念图-初期树苗")
![UndergroundMap](./assets/pic/UndergroundMap.png "概念图-地下土壤地图")

[gdd-wiki]: https://en.wikipedia.org/wiki/Game_design_document
[lviatyiaddr]: mailto:LviatYi@qq.com
