/* tslint:disable */
import { Asset } from './asset';
import { MeetingRoom } from './meeting-room';
export interface MeetingRoomAssets {
  asset?: Asset;
  assetId?: number;
  meetingRoom?: MeetingRoom;
  meetingRoomAssetId?: number;
  meetingRoomId?: number;
  quantity?: number;
}
